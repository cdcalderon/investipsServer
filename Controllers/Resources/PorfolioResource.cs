using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace investips.Controllers.Resources
{
    public class PorfolioResource
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public ICollection<int> Securities { get; set; }
        public PorfolioResource()  
        {
            Securities = new Collection<int>();
        }
    }
}