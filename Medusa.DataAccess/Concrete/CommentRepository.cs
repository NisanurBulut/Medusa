using Medusa.DataAccess.Context;
using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.DataAccess.Concrete
{
    public class CommentRepository : GenericDal<CommentEntity>, ICommentDal
    {
        private readonly DatabaseContext _context;
        public CommentRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
