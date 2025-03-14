using System.ComponentModel.DataAnnotations;
namespace Marketplace.Models;
class Role{
    [Key]
    public int Id{get;set;}
    public string Name{get;set;}
}