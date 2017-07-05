using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace investips.Controllers.Resources
{
    public class SavePorfolioResource
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public ICollection<int> Securities { get; set; }
        public SavePorfolioResource()  
        {
            Securities = new Collection<int>();
        }
    }
}