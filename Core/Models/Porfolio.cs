using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace investips.Core.Models
{
    public class Porfolio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<PorfolioSecurity> Securities { get; set; }
        public Porfolio()  
        {
            Securities = new Collection<PorfolioSecurity>();
        }
    }
}