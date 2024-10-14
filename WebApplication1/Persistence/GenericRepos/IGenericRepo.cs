
namespace WebApplication1.Persistence.GenericRepos;

public interface IGenericRepo<T> where T : class
{
    IQueryable<T> GetAll();
    //We mostly use GetAll, even for single oens
    T GetById(object id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
}
