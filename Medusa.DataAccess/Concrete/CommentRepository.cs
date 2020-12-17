using Medusa.DataAccess.Context;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.DataAccess.Concrete
{
    public class CommentRepository : GenericDal<CommentEntity>, ICommentDal
    {
        private readonly DatabaseContext _context;
        public CommentRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CommentEntity>> GetAllWithSubCommentsAsync(int blogId, int? parentId)
        {
            var result = new List<CommentEntity>();
            await GetComments(blogId, parentId, result);
            return result;
        }

        private async Task GetComments(int blogId, int? parentId, List<CommentEntity> result)
        {
            var comments = await _context.tComment.Where(a => a.BlogId == blogId && a.ParentCommentId == parentId)
                .OrderByDescending(a => a.PostedTime).ToListAsync();
            if (comments.Any())
            {
                foreach (var item in comments)
                {
                    // fill sub comments of parent comments
                    if (item.SubComments == null) 
                        item.SubComments = new List<CommentEntity>(); 

                    await GetComments(item.BlogId, item.Id, result); // recursive

                    if (!result.Contains(item)) 
                        result.Add(item);
                }
            }
        }
    }
}
