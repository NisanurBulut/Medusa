using IBlog.Entities;

namespace IBlog.Business.Interface
{
    // CommentEntity tip için IGenericDal dan kalıtsal geç
    public interface ICommentService : IGenericService<CommentEntity>
    {
    }
}
