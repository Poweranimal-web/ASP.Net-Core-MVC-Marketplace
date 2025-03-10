using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Marketplace.Models;
class Product{
    [Key]
    public int Id { get; set;}
    public string ProductId { get; set;}
    public string Name { get; set;}
    public int Price {get;set;}
    public int Amount {get;set;}
    public int IdDetails {get; set;}
    [ForeignKey(nameof(IdDetails))]
    public Detail details{get; set;}
}