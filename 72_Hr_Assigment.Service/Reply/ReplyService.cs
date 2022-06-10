using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Models.Reply;

namespace _72_Hr_Assigment.Service.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _context;
        public ReplyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateReplyAsync(ReplyRegister model)
        {
            var entity = new ReplyEntity
            {
                Text = model.Text,
            };
            _context.Replies.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;

        }
    }
}