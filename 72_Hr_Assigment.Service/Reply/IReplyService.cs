using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Models.Reply;

namespace _72_Hr_Assigment.Service.Reply
{
    public interface IReplyService
    {
        // Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync();
        Task<ReplyDetail> GetReplyByCommentIdAsync(int commentId);
        Task<bool> CreateReplyAsync(ReplyCreate request);
    }
}