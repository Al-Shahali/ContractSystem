


using Infrastructure.Context;
using System.Linq.Expressions;

namespace Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ContractSystemContext _context;
        private DbSet<TEntity> _entity;
        public Repository(ContractSystemContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }
        #region Create
        #region ADD
        public TEntity ADD(TEntity Model)
        {
            _entity.Add(Model);
            return Model;
        }
        public async ValueTask<TEntity> ADDAsync(TEntity Model)
        {
            await _entity.AddAsync(Model);
            return Model;
        }
        public void ADD(List<TEntity> Models)
        {
            _entity.AddRange(Models);
        }
        #endregion
        #endregion

        #region Read

        #region Enquiry =>(IQueryable)
        public IQueryable<TEntity> ENQ() => _entity;

        public IQueryable<TEntity> ENQ(params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _entity;
            foreach (var includeExpression in includes)
                result.Include(includeExpression);
            return result;
        }
        public IQueryable<TEntity> ENQ(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _entity.Where(whereCondition);
        }

        public IQueryable<TEntity> ENQ(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result.Include(includeExpression);
            return result;
        }

        #endregion 

        #region Enquiry =>(IQueryable)
        public IEnumerable<TEntity> GET(bool NoTracking = false)
        {
            if (NoTracking)
                return _entity.AsNoTracking();
            return _entity;
        }

        public IEnumerable<TEntity> GET(params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _entity;
            foreach (var includeExpression in includes)
                result.Include(includeExpression);
            return result;
        }

        public IEnumerable<TEntity> GET(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _entity.Where(whereCondition);
        }

        public IEnumerable<TEntity> GET(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result.Include(includeExpression);
            return result;
        }

        public async ValueTask<IEnumerable<TEntity>> GETAsync(bool NoTracking = false)
        {
            if (NoTracking)
                return await _entity.AsNoTracking().ToListAsync();
            return await _entity.ToListAsync();
        }

        public async ValueTask<IEnumerable<TEntity>> GETAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _entity;
            foreach (var includeExpression in includes)
                result.Include(includeExpression);
            return await result.ToListAsync();
        }

        public async ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _entity.Where(whereCondition).ToListAsync();
        }

        public async ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result.Include(includeExpression);
            return await result.ToListAsync();
        }

        #endregion

        #region Find
        public TEntity? FND(int Id)
        {
            return _entity.Find(Id);
        }
        public async ValueTask<TEntity?> FNDAsync(int Id)
        {
            return await _entity.FindAsync(Id);
        }
        #endregion

        #region SingleOrDefaultAsync
        public async ValueTask<TEntity?> SingleOrDefaultAsync()
        {
            return await _entity.FirstOrDefaultAsync();
        }
        public async ValueTask<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _entity.Where(whereCondition).FirstOrDefaultAsync();
        }
        public async ValueTask<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition, bool NoTacking = false, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result.Include(includeExpression);
            if (NoTacking)
                return await result.AsNoTracking().FirstOrDefaultAsync();
            return await result.FirstOrDefaultAsync();
        }
        #endregion

        #region Order 
        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _entity.OrderBy(whereCondition);
        }
        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _entity.OrderByDescending(whereCondition);
        }
        #endregion

        #endregion

        #region Update
        public void UPD(TEntity Model)
        {
            _entity.Attach(Model);
            _context.Entry(Model).State = EntityState.Modified;
        }
        public void UPD(params TEntity[] Models)
        {
            foreach (var model in Models)
            {
                _entity.Attach(model);
                _context.Entry(model).State = EntityState.Modified;
            }
        }
        public void UPD(List<TEntity> Models)
        {
            _entity.UpdateRange(Models);
            _context.Entry(Models).State = EntityState.Modified;
        }
        #endregion

        #region Delete
        public void DEL(TEntity entity)
        {
            _entity.Remove(entity);
        }
        public void DEL(params TEntity[] Models)
        {
            foreach(var model in Models)
                _entity.Remove(model);
        }
        public void DEL(List<TEntity> Models)
        {
            _entity.RemoveRange(Models);
        }
        #endregion

        #region SaveAll
        public bool SaveAll()
        {
            return  _context.SaveChanges() > 0;
        }
        public async ValueTask<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion


        public ICollection<TType> GetColumn<TType>(Expression<Func<TEntity, TType>> LamdaExpression) where TType : class
        {
            return _entity.Select(LamdaExpression).ToList();
        }
        public ICollection<TType> GetColumn<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class
        {
            return _entity.Where(where).Select(select).ToList();
        }

        public bool Any(Expression<Func<TEntity, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public bool checkState(TEntity entity, string state)
        {
            throw new NotImplementedException();
        }

        public DbSet<TEntity> GetContext()
        {
            return _entity;
        }


       

        
    }
}
