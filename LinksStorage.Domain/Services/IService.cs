namespace LinksStorage.Domain.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> Get(int id);
        public Task Add(TEntity entity);
        public Task AddRange(IEnumerable<TEntity> entities);
        public void Remove(TEntity entity);
        public void RemoveRange(IEnumerable<TEntity> entities);
        public void Update(TEntity entity);
        public void UpdateRange(IEnumerable<TEntity> entities);
    }
}
