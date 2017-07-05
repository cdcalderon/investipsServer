using System.Collections.Generic;
using System.Threading.Tasks;
using investips.Models;

namespace investips.Persistence
{
    public interface IPorfolioRepository
    {
         Task<Porfolio> GetPorfolio(int id, bool includeProps = true);
         Task<List<Porfolio>> GetPorfolios();
         void Add(Porfolio porfolio);
         void Remove(Porfolio porfolio);
    }
}