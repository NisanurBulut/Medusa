using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.DataAccess.Interface
{
    public interface ICommentDal:IGenericDal<CommentEntity>
    {
        public Task<List<CommentEntity>> GetAllWithSubCommentsAsync(int blogId, int? parentId);
    }
}
