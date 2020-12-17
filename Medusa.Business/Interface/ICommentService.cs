using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Interface
{
    // CommentEntity tip için IGenericDal dan kalıtsal geç
    public interface ICommentService : IGenericService<CommentEntity>
    {
        Task<List<CommentEntity>> GetAllWithSubCommentsAsync(int blogId, int? parentId);
    }
}
