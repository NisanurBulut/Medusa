using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.DataAccess.Concrete
{
    public class CommentRepository : GenericDal<CommentEntity>, ICommentDal
    {
    }
}
