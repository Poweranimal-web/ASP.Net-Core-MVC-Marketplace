using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Marketplace.Models;
class Customer{
    [Key]
    public int Id { get; set;}
    public string Name { get; set;}
    public string Email { get; set;}
    public string Password{ get; set;}
    public int IdRole{ get; set;}
    [ForeignKey(nameof(IdRole))]
    public Role role{ get; set;}
}