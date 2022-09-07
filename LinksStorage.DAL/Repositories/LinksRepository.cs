using LinksStorage.DAL.Entities;

namespace LinksStorage.DAL.Repositories
{
    public class LinksRepository : Repository<LinkEntity>, ILinksRepository
    {
        private readonly DataContext _context;

        public LinksRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
