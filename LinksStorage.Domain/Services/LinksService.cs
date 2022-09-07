using LinksStorage.DAL.Entities;
using LinksStorage.DAL.Repositories;

namespace LinksStorage.Domain.Services
{
    public class LinksService : ILinksService
    {
        private readonly ILinksRepository _repository;

        public LinksService(ILinksRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(LinkEntity entity)
        {
            await _repository.Add(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<LinkEntity> entities)
        {
            await _repository.AddRange(entities);
            await _repository.SaveChangesAsync();
        }

        public async Task<LinkEntity> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<LinkEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public void Remove(LinkEntity entity)
        {
            _repository.Remove(entity);
            _repository.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<LinkEntity> entities)
        {
            _repository.RemoveRange(entities);
            _repository.SaveChangesAsync();
        }

        public void Update(LinkEntity entity)
        {
            _repository.Update(entity);
            _repository.SaveChangesAsync();
        }

        public void UpdateRange(IEnumerable<LinkEntity> entities)
        {
            _repository.UpdateRange(entities);
            _repository.SaveChangesAsync();
        }
    }
}
