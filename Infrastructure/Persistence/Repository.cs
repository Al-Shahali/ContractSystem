


using Infrastructure.Context;
using System.Linq.Expressions;


namespace Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ContractSystemContext _context = null;
        private DbSet<TEntity> _entity;
        public Repository(ContractSystemContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public TEntity ADD(TEntity Model)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<TEntity> ADDAsync(TEntity Model)
        {
            await _entity.AddAsync(Model);
            return Model;
        }

        public void AddRange(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public bool checkState(TEntity entity, string state)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeletelistRange(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ENQ()
        {
            return _entity;
        }

        public IQueryable<TEntity> ENQ(params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ENQ(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ENQ(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ENQAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ENQAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ENQAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ENQAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public TEntity FND(int Id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> FNDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GET(bool NoTracking = false)
        {
            if (NoTracking)
                return _entity.AsNoTracking().ToList();
            return _entity.ToList();
        }

        public ValueTask<IEnumerable<TEntity>> GET(params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<TEntity>> GET(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<TEntity>> GET(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<IEnumerable<TEntity>> GETAsync(bool NoTracking = false)
        {
            if (NoTracking)
                return await _entity.AsNoTracking().ToListAsync();
            return await _entity.ToListAsync();
        }

        public ValueTask<IEnumerable<TEntity>> GETAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TType> GetColmounAsync<TType>(Expression<Func<TEntity, TType>> LamdaExpression) where TType : class
        {
            throw new NotImplementedException();
        }

        public DbSet<TEntity> GetContext()
        {
            throw new NotImplementedException();
        }

        public ICollection<TType> GetCoulmnAsync<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public ValueTask<TEntity> SingleOrDefaultAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition, bool NoTacking = false, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }


        public bool UPD(TEntity Model)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UPDAsync(TEntity Model)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
