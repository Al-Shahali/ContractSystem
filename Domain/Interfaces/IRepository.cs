using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        #region Enquiry =>(IEnumerable)
        IEnumerable<TEntity> GET(bool NoTracking = false);
        IEnumerable<TEntity> GET(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GET(Expression<Func<TEntity, bool>> whereCondition);
        IEnumerable<TEntity> GET(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);

        ValueTask<IEnumerable<TEntity>> GETAsync(bool NoTracking = false);
        ValueTask<IEnumerable<TEntity>> GETAsync(params Expression<Func<TEntity, object>>[] includes);
        ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition);
        ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);
        #endregion

        #region Enquiry =>(IQueryable)
        IQueryable<TEntity> ENQ();
        IQueryable<TEntity> ENQ(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> ENQ(Expression<System.Func<TEntity, bool>> whereCondition);
        IQueryable<TEntity> ENQ(Expression<System.Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);

        #endregion

        #region  Insert
        TEntity ADD(TEntity Model);
        void ADD(List<TEntity> Models);
        ValueTask<TEntity> ADDAsync(TEntity Model);
        #endregion

        #region Update
        void UPD(TEntity Model);
        void UPD(params TEntity[] Models);
        void UPD(List<TEntity> Models);
        #endregion

        #region Find
        TEntity? FND(int Id);
        ValueTask<TEntity?> FNDAsync(int Id);
        #endregion
        
        #region Delete 
        void DEL(TEntity entity);
        void DEL(params TEntity[] Models);
        void DEL(List<TEntity> Models);
        #endregion

        #region SingleOrDefault Async
        ValueTask<TEntity?> SingleOrDefaultAsync();
        ValueTask<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition);
        //ValueTask<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);
        ValueTask<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition, bool NoTacking = false, params Expression<Func<TEntity, object>>[] includes);

        #endregion

        #region OrderBy
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> whereCondition);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> whereCondition);
        #endregion

        #region main operation


   
        #endregion



        #region Get Current Identity
        ICollection<TType> GetColumn<TType>(Expression<Func<TEntity, TType>> LamdaExpression) where TType : class;
        ICollection<TType> GetColumn<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class;
        #endregion

        #region SaveAllAsync
        bool SaveAll();
        ValueTask<bool> SaveAllAsync();

        #endregion

        #region checkState
        public bool checkState(TEntity entity, string state);
        public DbSet<TEntity> GetContext();
        public bool Any(Expression<Func<TEntity, bool>> whereCondition);
        #endregion
    }

}
