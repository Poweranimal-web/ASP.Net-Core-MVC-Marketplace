using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Models;
class Detail{
    [Key]
    public int Id { get; set; }
    public string Description{ get; set;}
}