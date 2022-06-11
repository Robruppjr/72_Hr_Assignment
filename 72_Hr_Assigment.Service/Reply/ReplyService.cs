using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
            var replyEntity = new ReplyEntity
            {
                CommentId = _commentId,
                Text = request.Text
            };
            _context.Replies.Add(replyEntity);
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
                    Text = replyEntity.Text
                };
            
        }

    public async Task<bool> UpdateReplyAsync(ReplyUpdate request)
    {
        var replyEntity = await _context.Replies.FindAsync(request.Id);
        if (replyEntity?.CommentId != _commentId)
            return false;

            replyEntity.Text = request.Text;

        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }
}
