using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace investips.Core.Models
{
  public class Security
  {
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Symbol { get; set; }

  }
}