using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



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
    }
