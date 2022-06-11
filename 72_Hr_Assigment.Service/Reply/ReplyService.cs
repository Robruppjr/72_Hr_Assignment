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

        // public async Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync()
        // {
        //     var replies = await _context.Replies
        //         .Where(entity => entity.CommentId == _commentId)
        //         .Select(entity => new ReplyListItem
        //         {
        //             Id = entity.Id,
        //             Text = entity.Text,
        //         })
        //         .ToListAsync();
        // return replies;
        // }

        public async Task<ReplyDetail> GetReplyByCommentIdAsync(int commentId)
        {
            //Find the first reply that has the given Id(commentID) that matches the requesting commentID
            var replyEntity = await _context.Replies
                .FirstOrDefaultAsync(e => 
                    e.Id == commentId
                );
                //If replyEntity is null then return null, otherwise initialize and return a new noteDetail
                return replyEntity is null ? null : new ReplyDetail
                {
                    CommentId = replyEntity.OwnerId,
                    Text = replyEntity.Text
                };
            
        }
    }
}