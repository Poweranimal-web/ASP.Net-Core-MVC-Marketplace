namespace Marketplace.Models;
interface IService<T>{
    void CreateEntity(T entity);
    List<T> GetAll();
    void UpdateEntity(T entity);
    void DeleteEntity(T entity);
    void DeleteEntities(params T[] entities);
    void UpdateEntities(params T[] entities);
    T GetEntity(int id);
}