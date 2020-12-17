using Medusa.DataAccess.Context;
using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.DataAccess.Concrete
{
    public class AppUserRepository : GenericDal<AppUserEntity>, IAppUserDal
    {
        private readonly DatabaseContext _context;
        public AppUserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
