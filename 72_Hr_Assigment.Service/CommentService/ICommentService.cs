using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface ICommentService
    {

        Task<bool> CreateCommentAsync (CommentCreateDTO commentCreateDTO);
        Task<bool> DeleteCommentAsync(int commentId);

        Task<bool> UpdateCommentAsync(CommentEditDTO request);

        Task<CommentDetailDTO> GetCommentsByPostIdAsync (int postId);


    }
