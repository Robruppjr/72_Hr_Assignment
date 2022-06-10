using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class CommentService : ICommentService
    {

        private readonly ApplicationDbContext _context;

       public async Task<bool> CreateComment (CommentCreateDTO commentCreateDTO)
       {
           CommentEntity comment = new CommentEntity ()
           {
               Text = commentCreateDTO.Text
           };

           await _context.Comment.AddAsync(comment);
           var numberOfChanges = await _context.SaveChangesAsync();
           return numberOfChanges == 1;
       }
    }
