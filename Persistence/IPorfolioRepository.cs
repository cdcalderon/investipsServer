using System.Threading.Tasks;
using investips.Models;

namespace investips.Persistence
{
    public interface IPorfolioRepository
    {
         Task<Porfolio> GetPorfolio(int id);
    }
}