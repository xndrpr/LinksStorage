using LinksStorage.DAL.Entities;

namespace LinksStorage.DAL.Repositories
{
    public class UsersRepository : Repository<UserEntity>, IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
