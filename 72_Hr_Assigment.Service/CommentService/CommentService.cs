using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CommentService : ICommentService
    {

        private readonly int _postId;
        private readonly ApplicationDbContext _context;

        private readonly ICommentService _commentService;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCommentAsync (CommentCreateDTO commentCreateDTO)
        {
           CommentEntity comment = new CommentEntity
           {
            PostId =    commentCreateDTO.PostId,

               Text = commentCreateDTO.Text
           };

            _context.Comment.Add(comment);
           var numberOfChanges = await _context.SaveChangesAsync();
           return numberOfChanges == 1;
        }

       public async Task<IEnumerable<CommentListItemDTO>> GetCommentsByPostIdAsync(int postId)
       {
         var comments = await _context.Comment
            .Where(entity =>entity.PostId == postId)
            .Select(entity => new CommentListItemDTO
            {
                Id = entity.Id,
                Text = entity.Text
            })
            .ToListAsync();

            return comments;
       }
    

       public async Task<bool> UpdateCommentAsync(CommentEditDTO request)
       {
           var commentEntity = await _context.Comment.FindAsync(request.Id);
           if(commentEntity == null)
           {
               return false;
           }

           commentEntity.Text = request.Text;

           var numberOfChanges = await _context.SaveChangesAsync();
           return numberOfChanges == 1;
       }

       public async Task<bool> DeleteCommentAsync(int commentId)
       {
           var commentEntity = await _context.Comment.FindAsync(commentId);
           if(commentEntity == null)
           {
               return false;
           }

           _context.Comment.Remove(commentEntity);
           return await _context.SaveChangesAsync()==1;
       }
    }
