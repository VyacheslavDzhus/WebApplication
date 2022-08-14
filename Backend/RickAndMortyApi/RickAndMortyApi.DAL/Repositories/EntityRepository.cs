using Microsoft.EntityFrameworkCore;

namespace RickAndMortyApi.DAL.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly RickAndMortyDbContext dbContext;
        private readonly DbSet<T> dbSet;
        public EntityRepository(RickAndMortyDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public async Task Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int entityId)
        {
            return await dbSet.FindAsync(entityId).AsTask();
        }

        public async Task<T> Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;

            await this.dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
