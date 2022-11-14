using Cafe.Application.Interfaces;

namespace Cafe.Application
{
    public class CafeContextHandler
    {
        protected ICafeDbContext _context;

        public CafeContextHandler(ICafeDbContext context)
        {
            _context = context;
        }
    }
}
