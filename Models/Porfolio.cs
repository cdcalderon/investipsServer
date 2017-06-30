using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace investips.Models
{
    public class Porfolio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Security> Securities { get; set; }
        public Porfolio()  
        {
            Securities = new Collection<Security>();
        }
        
    }
}