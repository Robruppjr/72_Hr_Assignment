using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Models.Reply;
using Microsoft.EntityFrameworkCore;

namespace _72_Hr_Assigment.Service.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly int _commentId;
        private readonly ApplicationDbContext _context;
        public ReplyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateReplyAsync(ReplyCreate request)
        {
            var entity = new ReplyEntity
            {
                Text = request.Text,
            };
            _context.Replies.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;

        }

        public async Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync()
        {
            var replies = await _context.Replies
                .Where(entity => entity.CommentId == _commentId)
                .Select(entity => new ReplyListItem
                {
                    Id = entity.Id,
                    Text = entity.Text,
                })
                .ToListAsync();
        return replies;
        }

        public Task<IEnumerable<ReplyListItem>> GetReplyByCommentId()
        {
            throw new NotImplementedException();
        }
    }
}