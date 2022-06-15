using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Models.Post;
using Microsoft.EntityFrameworkCore;



    public class PostService : IPostService
    {
        private readonly int _postId;
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreatePostAsync(PostCreate request)
        {
            var postEntity = new PostEntity
            {
                Id = _postId,
                Title = request.Title,
                Text = request.Text
            };
             _context.Posts.Add(postEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<PostDetail> GetPostByPostIdAsync(int postId)
        {
            var postEntity = await _context.Posts
                .FirstOrDefaultAsync(e =>
                    e.Id == postId
                );

                return postEntity is null ? null : new PostDetail
                {
                    Text = postEntity.Text
                };
                
        }
    }
