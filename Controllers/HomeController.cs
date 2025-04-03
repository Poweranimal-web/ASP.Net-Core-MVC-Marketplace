using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Search"] = "";
        using (MarketPlaceDbContext context = new  MarketPlaceDbContext()){
            ProductOperations<Product,MarketPlaceDbContext> productOperations = new ProductOperations<Product,MarketPlaceDbContext>(context);
            List<Product> products = productOperations.GetAll();
            return View(products);
        }
    }
    [HttpPost]
    public IActionResult Index([FromBody] Text text) // dynamic search by text
    {
        ViewData["Search"] = text.text;
        using (MarketPlaceDbContext context = new MarketPlaceDbContext()){
            ProductOperations<Product,MarketPlaceDbContext> productOperations = new ProductOperations<Product,MarketPlaceDbContext>(context);
            List<Product> products = context.products.FromSqlInterpolated($"SELECT * FROM products WHERE Name LIKE {text.text + "%"}").ToList(); 
            return Json(products);
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
    public IActionResult LogOut(){
        HttpContext.SignOutAsync();
        return Redirect("/");
    }
    [HttpPost]
    public IActionResult SignIn(string email, string password){
        using (MarketPlaceDbContext context = new MarketPlaceDbContext()){
            CustomerOperations<Customer, MarketPlaceDbContext> customerOperations 
            = new CustomerOperations<Customer, MarketPlaceDbContext>(context);
            bool exist = customerOperations.Exist(email,password);
            if (exist){
                List<Claim> claims = new List<Claim>(){
                        new Claim("email", email),
                        new Claim("role", "member")
                    };
                HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims,"Cookies","email","role")));
                HttpContext.Session.SetString("email", email);
                return Redirect("/");    
            }
            else{
                return View(true);
            }
        }
    }
    [Authorize]
    public IActionResult Profile(){
        using (MarketPlaceDbContext context = new MarketPlaceDbContext()){
            CustomerOperations<Customer, MarketPlaceDbContext> customerOperations 
            = new CustomerOperations<Customer, MarketPlaceDbContext>(context);
            StringBuilder email = new StringBuilder(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email")?.Value);
            Customer customer = customerOperations.GetEntity(email.ToString());
            return View(customer);
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
                    List<Claim> claims = new List<Claim>(){
                        new Claim("email", customer.Email),
                        new Claim("role", "member")
                    };
                    HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims,"Cookies","email","role")));
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
