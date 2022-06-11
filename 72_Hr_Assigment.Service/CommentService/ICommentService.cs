using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface ICommentService
    {

        Task<bool> CreateComment (CommentCreateDTO commentCreateDTO);
        Task<bool> DeleteComment(int commentId);

        Task<bool> UpdateCommentAsync(CommentEditDTO request);

        Task<CommentDetailDTO> GetCommentsByPostIdAsync (int postId);
    }
