using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Models.Post;

namespace _72_Hr_Assigment.Service.Post
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(PostCreate request);
    }
}