using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Persistence.Entities;

namespace WebApplication1.Persistence.Repositories;

internal class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepo(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public virtual T GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Save()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during Save??: {ex.Message}");
            throw; 
        }
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }
}