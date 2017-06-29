using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace investips.Models
{
  public class Security
  {
    public int Id { get; set; }
    public string Symbol { get; set; }

    public ICollection<Porfolio> Porfolios {get; set;} 

    public Security()
    {
        Porfolios = new Collection<Porfolio>();
    }

  }
}