using Marketplace.Models;
class CustomerOperations<T, U> : IService<T> where T : Customer where U : MarketPlaceDbContext 
{
    U Context = default;
    public CustomerOperations(U context){
        this.Context = context;
    }
    public void CreateEntity(T entity){
        Context.customers.Add(entity);
        Context.SaveChanges();
    }
    public List<T> GetAll(){
        return Context.customers.Cast<T>().ToList();
    }
    public void UpdateEntity(T entity){
        Context.customers.Update(entity);
        Context.SaveChanges();
    }
    public void DeleteEntity(T entity){
        Context.customers.Remove(entity);
        Context.SaveChanges();
    }
    public void DeleteEntities(params T[] entities){
        Context.customers.AddRange(entities);
        Context.SaveChanges();
    }
    public void UpdateEntities(params T[] entities){
        Context.customers.UpdateRange(entities);
        Context.SaveChanges();
    }
    public bool Exist(T entity){
        return Context.customers.Any(customer => customer.Email == entity.Email);
    }
    public bool Exist(string email, string password){
        return Context.customers.Any(customer => customer.Email == email & customer.Password == password);
    }
    public T GetEntity(int id){
        return Context.customers.Cast<T>().Where(customer => customer.Id == id).FirstOrDefault();
    }
    public T GetEntity(string email){
        return Context.customers.Cast<T>().Where(customer => customer.Email == email).FirstOrDefault();
    }

}