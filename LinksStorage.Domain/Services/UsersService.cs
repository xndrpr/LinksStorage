using LinksStorage.DAL.Entities;
using LinksStorage.DAL.Repositories;

namespace LinksStorage.Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(UserEntity entity)
        {
            await _repository.Add(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<UserEntity> entities)
        {
            await _repository.AddRange(entities);
            await _repository.SaveChangesAsync();
        }

        public async Task<UserEntity> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public void Remove(UserEntity entity)
        {
            _repository.Remove(entity);
            _repository.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<UserEntity> entities)
        {
            _repository.RemoveRange(entities);
            _repository.SaveChangesAsync();
        }

        public void Update(UserEntity entity)
        {
            _repository.Update(entity);
            _repository.SaveChangesAsync();
        }

        public void UpdateRange(IEnumerable<UserEntity> entities)
        {
            _repository.UpdateRange(entities);
            _repository.SaveChangesAsync();
        }
    }
}
