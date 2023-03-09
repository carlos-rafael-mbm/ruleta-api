using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ruleta_api.Models;
using ruleta_api.Models.DTO;
using ruleta_api.Repository.IRepository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ruleta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository betRepository;
        private readonly IMapper mapper;

        public BetController(IBetRepository betRepository, IMapper mapper)
        {
            this.betRepository = betRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBets()
        {
            var listBets = betRepository.GetBets();
            var listBetsDTO = new List<BetDTO>();
            foreach (var bet in listBets)
            {
                listBetsDTO.Add(mapper.Map<BetDTO>(bet));
            }
            return Ok(listBetsDTO);
        }

        [HttpGet("{betUser}", Name="GetBet")]
        public IActionResult GetBet(string betUser)
        {
            var bet = betRepository.GetBet(betUser);
            if (bet == null)
                return NotFound();
            var betDTO = mapper.Map<BetDTO>(bet);
            return Ok(betDTO);
        }

        [HttpPost]
        public IActionResult CreateBet([FromBody] BetDTO betDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (betDTO == null)
                return BadRequest(ModelState);
            if (betRepository.ExistsBet(betDTO.User))
            {
                ModelState.AddModelError("", "El usuario ya existe");
                return StatusCode(404, ModelState);
            }
            var bet = mapper.Map<Bet>(betDTO);
            if (!betRepository.CreateBet(bet))
            {
                ModelState.AddModelError("", "El usuario ya existe");
                return StatusCode(404, ModelState);
            }
            return CreatedAtRoute("GetBet", new { betUser = bet.User }, bet);
        }

        [HttpPut("{betUser}", Name = "GetBet")]
        public IActionResult UpdateBet(string betUser, [FromBody] BetDTO betDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (betDTO == null || betUser.ToUpper() != betDTO.User.ToUpper())
                return BadRequest(ModelState);
            var bet = mapper.Map<Bet>(betDTO);
            if (!betRepository.UpdateBet(bet))
            {
                ModelState.AddModelError("", $"Algo salió mal actualizando el registro de {betDTO.User}");
                return StatusCode(404, ModelState);
            }
            return NoContent();
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetRouletteResult()
        {
            Random random = new Random();
            int resultNumber = random.Next(1, 37);
            string resultColor = resultNumber % 2 == 0 ? "negro" : "rojo";
            string json = JsonConvert.SerializeObject(new
            {
                number = resultNumber,
                color = resultColor
            });
            return Ok(json);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetBetResult([FromQuery] float amount, [FromQuery] bool isSuccess, [FromQuery] string betType)
        {
            float prize = 0;
            if (!isSuccess)
            {
                prize = amount * -1;
            }
            else
            {
                if (betType.Equals("color"))
                {
                    prize = amount / 2;
                }
                if (betType.Equals("base"))
                {
                    prize = amount;
                }
                if (betType.Equals("number"))
                {
                    prize = amount * 3;
                }
            }
            string json = JsonConvert.SerializeObject(new
            {
                prize = prize
            });
            return Ok(json);
        }
    }
}
