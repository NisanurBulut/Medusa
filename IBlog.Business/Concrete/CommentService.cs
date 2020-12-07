using IBlog.Business.Interface;
using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.Business.Concrete
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
