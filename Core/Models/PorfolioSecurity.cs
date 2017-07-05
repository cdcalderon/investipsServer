using System.ComponentModel.DataAnnotations.Schema;

namespace investips.Core.Models
{
    [Table("PorfolioSecurities")]
    public class PorfolioSecurity
    {
        public int PorfolioId { get; set; }
        public int SecurityId { get; set; }
        public Porfolio Porfolio { get; set; }
        public Security Security { get; set; }
    }
}