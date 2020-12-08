using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.Business.Concrete
{
    public class CommentService : GenericService<CommentEntity>, ICommentService
    {
        private IGenericDal<CommentEntity> _genericDal;
        public CommentService(IGenericDal<CommentEntity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
