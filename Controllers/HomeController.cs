using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Models;

namespace Marketplace.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        using (MarketPlaceDbContext context = new  MarketPlaceDbContext()){
            ProductOperations<Product,MarketPlaceDbContext> productOperations = new ProductOperations<Product,MarketPlaceDbContext>(context);
            List<Product> products = productOperations.GetAll();
            return View(products);
        }
    }
    public IActionResult Details(int id){
        using (MarketPlaceDbContext context = new MarketPlaceDbContext()){
            ProductOperations<Product,MarketPlaceDbContext> productOperations = new ProductOperations<Product,MarketPlaceDbContext>(context);
            Product product = productOperations.GetEntity(id);
            return View(product);
        }

    }

    public IActionResult Privacy()
    {
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
