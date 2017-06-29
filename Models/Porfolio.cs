using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace investips.Models
{
    public class Porfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Security> Securities { get; set; }
        public Porfolio()  
        {
            Securities = new Collection<Security>();
        }
        
    }
}