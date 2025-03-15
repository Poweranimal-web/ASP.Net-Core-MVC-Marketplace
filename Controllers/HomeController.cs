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
    public IActionResult SignUp(){
        ViewData["RepeatPassword"] = false;
        return View();
    }
    public IActionResult SignIn(){
        return View();
    }
    [HttpPost]
    public IActionResult SignIn(string email, string password){
        using (MarketPlaceDbContext context = new MarketPlaceDbContext()){
            CustomerOperations<Customer, MarketPlaceDbContext> customerOperations 
            = new CustomerOperations<Customer, MarketPlaceDbContext>(context);
            bool exist = customerOperations.Exist(email,password);
            if (exist){
                return Redirect("/");    
            }
            else{
                return View(true);
            }
        }
    }
    [HttpPost]
    public IActionResult SignUp(string name, string email, string password, string repeat_password){        
        ViewData["RepeatPassword"] = false;
        if (password.Equals(repeat_password)){
            using (MarketPlaceDbContext context = new MarketPlaceDbContext()){
                CustomerOperations<Customer, MarketPlaceDbContext> customerOperations 
                = new CustomerOperations<Customer, MarketPlaceDbContext>(context);
                Customer customer = new Customer()
                {Name=name, Email=email, Password=password, IdRole=1};
                bool exist = customerOperations.Exist(customer);
                if (!exist){
                    customerOperations.CreateEntity(customer);
                    return Redirect("/");
                }
                else{
                    return View(true);
                }
            }
        }
        else{
            ViewData["RepeatPassword"] = true;
            return View();
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
