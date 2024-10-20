
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Persistence.Entities;

namespace WebApplication1.Persistence.Repositories;

public interface IGenericRepo<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    T GetById(object id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
    IDbContextTransaction BeginTransaction();
}
