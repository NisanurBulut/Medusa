using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.DataAccess.Concrete
{
    public class CommentRepository : GenericDal<CommentEntity>, ICommentDal
    {
    }
}
