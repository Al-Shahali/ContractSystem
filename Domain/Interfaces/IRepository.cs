using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        #region Enquiry  =>(IEnumerable)
       IEnumerable<TEntity> GET(bool NoTracking = false);
        ValueTask<IEnumerable<TEntity>> GET(params Expression<Func<TEntity, object>>[] includes);
        ValueTask<IEnumerable<TEntity>> GET(Expression<Func<TEntity , bool>> whereCondition);
        ValueTask<IEnumerable<TEntity>> GET(Expression<Func<TEntity , bool>> whereCondition, params Expression<Func<TEntity , object>>[] includes);

        ValueTask<IEnumerable<TEntity>> GETAsync(bool NoTracking = false);
        ValueTask<IEnumerable<TEntity>> GETAsync(params Expression<Func<TEntity , object>>[] includes);
        ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition);
        ValueTask<IEnumerable<TEntity>> GETAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);
        #endregion

        #region  GetALL Async =>(IQueryable)
        IQueryable<TEntity> ENQ();
        IQueryable<TEntity> ENQ(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> ENQ(Expression<System.Func<TEntity, bool>> whereCondition);
        IQueryable<TEntity> ENQ(Expression<System.Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> ENQAsync();
        IQueryable<TEntity> ENQAsync(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> ENQAsync(Expression<System.Func<TEntity, bool>> whereCondition);
        IQueryable<TEntity> ENQAsync(Expression<System.Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);
        #endregion

        #region  Insert
        TEntity ADD(TEntity Model);
        ValueTask<TEntity> ADDAsync(TEntity Model);
        void AddRange(List<TEntity> entities);
        #endregion

        #region Update
        bool UPD(TEntity Model);
        ValueTask<bool> UPDAsync(TEntity Model);
        #endregion

        #region Find
        TEntity FND(int Id);
        ValueTask<TEntity> FNDAsync(int Id);
        #endregion

        #region Delete 


        #endregion

        #region SingleOrDefault Async
        ValueTask<TEntity> SingleOrDefaultAsync();
        ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition);
        ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition, params Expression<Func<TEntity, object>>[] includes);
        ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition, bool NoTacking = false, params Expression<Func<TEntity, object>>[] includes);

        #endregion

        #region OrderBy
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> whereCondition);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> whereCondition);
        #endregion



        //bool DEL(TEntity Model);


        //IQueryable<TEntity> ENQENC();
        //TEntity FNDENC(int Id);
        //TEntity ConvertString(TEntity Model);
        //int GetKey(TEntity Model);



        //bool UPDENC(TEntity Model);
        //bool DELENC(TEntity Model);

        //ValueTask<bool> DELAsync(TEntity Model);
        //ValueTask<TEntity> ADDENCAsync(TEntity Model);
        //ValueTask<bool> DELENCAsync(TEntity Model);


        #region main operation


        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(params TEntity[] entities);
        void DeletelistRange(List<TEntity> entities);
        #endregion

        #region GetById Async
        ValueTask<TEntity> GetByIdAsync(Guid id);




        #endregion

        #region Get Current Identity

        ICollection<TType> GetColmounAsync<TType>(Expression<Func<TEntity, TType>> LamdaExpression) where TType : class;

        ICollection<TType> GetCoulmnAsync<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class;
        #endregion

        #region SaveAllAsync
        ValueTask<bool> SaveAllAsync();

        #endregion

        #region checkState
        public bool checkState(TEntity entity, string state);
        public DbSet<TEntity> GetContext();
        public bool Any(Expression<Func<TEntity, bool>> whereCondition);
        #endregion
    }

}
