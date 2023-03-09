using ruleta_api.Data;
using ruleta_api.Models;
using ruleta_api.Repository.IRepository;

namespace ruleta_api.Repository
{
    public class BetRepository : IBetRepository
    {
        private readonly ApplicationDbContext context;

        public BetRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CreateBet(Bet bet)
        {
            context.Bets.Add(bet);
            return Save();
        }

        public bool DeleteBet(Bet bet)
        {
            context.Bets.Remove(bet);
            return Save();
        }

        public bool ExistsBet(string user)
        {
            bool betExists = context.Bets.Any(bet => bet.User.ToUpper().Trim() == user.ToUpper().Trim());
            return betExists;
        }

        public Bet GetBet(string user)
        {
            return context.Bets.FirstOrDefault(bet => bet.User == user);
        }

        public ICollection<Bet> GetBets()
        {
            return context.Bets.OrderBy(bet => bet.User).ToList();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public bool UpdateBet(Bet bet)
        {
            context.Bets.Update(bet);
            return Save();
        }
    }
}
