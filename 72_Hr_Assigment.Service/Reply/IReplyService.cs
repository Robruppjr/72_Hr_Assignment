using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



    public interface IReplyService
    {
        // Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync();
        Task<ReplyDetail> GetReplyByCommentIdAsync(int commentId);
        Task<bool> CreateReplyAsync(ReplyCreate request);
    }
