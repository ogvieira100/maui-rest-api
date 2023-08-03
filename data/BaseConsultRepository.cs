using Dapper;
using domain;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace data
{
    public class BaseConsultRepository<TEntity> : IBaseConsultRepository<TEntity> where TEntity : class
    {
        readonly AplicationpContext _Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseConsultRepository(AplicationpContext Context)
        {
            _Context = Context;
            DbSet = _Context.Set<TEntity>();
        }

        public void Dispose() => GC.SuppressFinalize(this);
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.AnyAsync(predicate);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSet.ToListAsync();
        public async Task<TEntity> GetByIdAsync(Int64 id) => await DbSet.FindAsync(id);
        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.Where(predicate).ToListAsync();
        public IQueryable<TEntity> GetQueryable() => DbSet.AsQueryable();
        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(string sql, object par = null) => await _Context.Database.GetDbConnection().QueryAsync<TModel>(sql, par);
    }
}
