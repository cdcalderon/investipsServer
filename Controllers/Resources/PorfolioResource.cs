using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace investips.Controllers.Resources
{
    public class PorfolioResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SecurityResource> Securities { get; set; }
        public PorfolioResource()  
        {

            Securities = new Collection<SecurityResource>();
        }
    }
}