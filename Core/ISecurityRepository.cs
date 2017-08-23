using System.Threading.Tasks;
using investips.Core.Models;

namespace investips.Core
{
    public interface ISecurityRepository
    {
        Task<Security> GetSecurity(int id);
         void Add(Security security);
    }
}