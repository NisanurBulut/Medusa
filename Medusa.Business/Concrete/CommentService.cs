using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Concrete
{
    public class CommentService : GenericService<CommentEntity>, ICommentService
    {
        private readonly IGenericDal<CommentEntity> _genericDal;
        private readonly ICommentDal _commentDal;

        public CommentService(IGenericDal<CommentEntity> genericDal, ICommentDal commentDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _commentDal = commentDal;
        }

        public async Task<List<CommentEntity>> GetAllWithSubCommentsAsync(int blogId, int? parentId)
        {
            return await _commentDal.GetAllWithSubCommentsAsync(blogId, parentId);
        }
    }
}
