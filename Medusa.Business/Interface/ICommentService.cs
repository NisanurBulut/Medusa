using Medusa.Entities;

namespace Medusa.Business.Interface
{
    // CommentEntity tip için IGenericDal dan kalıtsal geç
    public interface ICommentService : IGenericService<CommentEntity>
    {
    }
}
