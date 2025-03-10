using Microsoft.EntityFrameworkCore;
namespace Marketplace.Models;
class MarketPlaceDbContext : DbContext{
    public DbSet<Product> products{get;set;}
    public DbSet<Detail> details {get;set;}
    public MarketPlaceDbContext(){
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
        optionBuilder.UseSqlite("Data Source=test.db");
    }
    public void CreateInitial(){
        details.AddRange(new Detail { Id = 1, Description = "Fresh organic bananas, rich in potassium."},
                new Detail { Id = 2, Description = "Crisp and juicy red apples, great for snacks." },
                new Detail { Id = 3, Description = "Sweet and tangy oranges, full of vitamin C."},
                new Detail { Id = 4, Description = "Fresh strawberries, perfect for desserts." },
                new Detail { Id = 5, Description = "Sweet and antioxidant-rich blueberries."},
                new Detail { Id = 6, Description = "Crunchy organic carrots, great for salads."});
        this.SaveChanges();
        products.AddRange( // Fruits & Vegetables
                new Product { Id = 1, ProductId = "P001", Name = "Banana", Price = 1, Amount = 100, IdDetails = 1 },
                new Product { Id = 2, ProductId = "P002", Name = "Apple", Price = 2, Amount = 100, IdDetails = 2 },
                new Product { Id = 3, ProductId = "P003", Name = "Orange", Price = 2, Amount = 80, IdDetails = 3 },
                new Product { Id = 4, ProductId = "P004", Name = "Strawberries", Price = 4, Amount = 50, IdDetails = 4 },
                new Product { Id = 5, ProductId = "P005", Name = "Blueberries", Price = 5, Amount = 40, IdDetails = 5 },
                new Product { Id = 6, ProductId = "P006", Name = "Carrots", Price = 2, Amount = 90, IdDetails = 6 },
                new Product { Id = 7, ProductId = "P007", Name = "Potatoes", Price = 3, Amount = 100, IdDetails = 1 },
                new Product { Id = 8, ProductId = "P008", Name = "Tomatoes", Price = 4, Amount = 85, IdDetails = 2 },
                new Product { Id = 9, ProductId = "P009", Name = "Lettuce", Price = 2, Amount = 60, IdDetails = 3 },
                new Product { Id = 10, ProductId = "P010", Name = "Spinach", Price = 3, Amount = 70, IdDetails = 4 },

                // Dairy
                new Product { Id = 11, ProductId = "P011", Name = "Milk 1L", Price = 3, Amount = 50, IdDetails = 5 },
                new Product { Id = 12, ProductId = "P012", Name = "Cheddar Cheese", Price = 5, Amount = 40, IdDetails = 6 },
                new Product { Id = 13, ProductId = "P013", Name = "Butter", Price = 4, Amount = 40, IdDetails = 6 },
                new Product { Id = 14, ProductId = "P014", Name = "Eggs (12-pack)", Price = 5, Amount = 50, IdDetails = 6 },
                new Product { Id = 15, ProductId = "P015", Name = "Yogurt (Plain)", Price = 3, Amount = 45, IdDetails = 6 },

                // Meat & Seafood
                new Product { Id = 16, ProductId = "P016", Name = "Chicken Breast", Price = 6, Amount = 25, IdDetails = 6 },
                new Product { Id = 17, ProductId = "P017", Name = "Beef Steak", Price = 10, Amount = 20, IdDetails = 6 },
                new Product { Id = 18, ProductId = "P018", Name = "Salmon Fillet", Price = 8, Amount = 20, IdDetails = 6 },
                new Product { Id = 19, ProductId = "P019", Name = "Pork Chops", Price = 7, Amount = 30, IdDetails = 6 },
                new Product { Id = 20, ProductId = "P020", Name = "Ground Turkey", Price = 6, Amount = 35, IdDetails = 6 },

                // Grains & Pantry Staples
                new Product { Id = 21, ProductId = "P021", Name = "Brown Bread", Price = 2, Amount = 30, IdDetails = 1 },
                new Product { Id = 22, ProductId = "P022", Name = "Rice 1kg", Price = 4, Amount = 70, IdDetails = 2 },
                new Product { Id = 23, ProductId = "P023", Name = "Pasta (Spaghetti)", Price = 2, Amount = 60, IdDetails = 3 },
                new Product { Id = 24, ProductId = "P024", Name = "Oatmeal 500g", Price = 3, Amount = 50, IdDetails = 4 },
                new Product { Id = 25, ProductId = "P025", Name = "Lentils 1kg", Price = 4, Amount = 45, IdDetails = 5 },

                // Beverages
                new Product { Id = 26, ProductId = "P026", Name = "Green Tea 50g", Price = 5, Amount = 30, IdDetails = 6 },
                new Product { Id = 27, ProductId = "P027", Name = "Coffee 200g", Price = 8, Amount = 35, IdDetails = 5 },
                new Product { Id = 28, ProductId = "P028", Name = "Orange Juice 1L", Price = 4, Amount = 40, IdDetails = 4 },
                new Product { Id = 29, ProductId = "P029", Name = "Coconut Water 500ml", Price = 3, Amount = 25, IdDetails = 3 },
                new Product { Id = 30, ProductId = "P030", Name = "Sparkling Water 750ml", Price = 2, Amount = 50, IdDetails = 2 });
        this.SaveChanges();
    }
}