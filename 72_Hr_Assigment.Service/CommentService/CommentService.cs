using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CommentService : ICommentService
    {

        private readonly ApplicationDbContext _context;

       public async Task<bool> CreateCommentAsync (CommentCreateDTO commentCreateDTO)
       {
           CommentEntity comment = new CommentEntity ()
           {
               Text = commentCreateDTO.Text
           };

           await _context.Comment.AddAsync(comment);
           var numberOfChanges = await _context.SaveChangesAsync();
           return numberOfChanges == 1;
       }

       //get all comments

    

       public async Task<CommentDetailDTO> GetCommentsByPostIdAsync (int postId)
       {
            var commentEntity = await _context.Comment.FirstOrDefaultAsync(e => e.Id == e.PostId);

            return commentEntity is null ? null : new CommentDetailDTO
            {
                Id = commentEntity.Id,
                Text = commentEntity.Text
            };

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
