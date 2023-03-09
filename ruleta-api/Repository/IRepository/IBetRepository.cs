using ruleta_api.Models;

namespace ruleta_api.Repository.IRepository
{
    public interface IBetRepository
    {
        ICollection<Bet> GetBets();
        Bet GetBet(string user);
        bool ExistsBet(string user);
        bool CreateBet(Bet bet);
        bool UpdateBet(Bet bet);
        bool DeleteBet(Bet bet);
        bool Save();
    }
}
