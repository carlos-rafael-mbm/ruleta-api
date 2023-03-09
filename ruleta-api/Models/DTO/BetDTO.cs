using System.ComponentModel.DataAnnotations;

namespace ruleta_api.Models.DTO
{
    public class BetDTO
    {
        [Required(ErrorMessage = "El campo usuario es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo usuario debe tener máximo 20 caracteres")]
        public string User { get; set; }

        [Required(ErrorMessage = "El campo monto es obligatorio")]
        public float Amount { get; set; }
    }
}
