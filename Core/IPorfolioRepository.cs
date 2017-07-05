using System.Collections.Generic;
using System.Threading.Tasks;
using investips.Core.Models;

namespace investips.Core
{
    public interface IPorfolioRepository
    {
         Task<Porfolio> GetPorfolio(int id, bool includeProps = true);
         Task<List<Porfolio>> GetPorfolios();
         void Add(Porfolio porfolio);
         void Remove(Porfolio porfolio);
    }
}