using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models;
class ProductOperations<T, U> : IService<T> where T : Product where U : MarketPlaceDbContext 
{
    U Context = default;
    public ProductOperations(U context){
        this.Context = context;
    }
    public void CreateEntity(T entity){
        Context.products.Add(entity);
        Context.SaveChanges();
    }
    public List<T> GetAll(){
        return Context.products.Cast<T>().ToList();
    }
    public void UpdateEntity(T entity){
        Context.products.Update(entity);
        Context.SaveChanges();
    }
    public void DeleteEntity(T entity){
        Context.products.Remove(entity);
        Context.SaveChanges();
    }
    public void DeleteEntities(params T[] entities){
        Context.products.AddRange(entities);
        Context.SaveChanges();
    }
    public void UpdateEntities(params T[] entities){
        Context.products.UpdateRange(entities);
        Context.SaveChanges();
    }
    public T GetEntity(int id){
        return Context.products.Cast<T>().Where(product => product.Id == id).FirstOrDefault();
    }

}