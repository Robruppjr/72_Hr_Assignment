using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Models.Post;
using _72_Hr_Assigment.Service.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _72_Hr_Assignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService service)
        {
            _postService = service;
        }
        
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (await _postService.CreatePostAsync(request))
            return Ok("Succesfully posted!");

        return BadRequest("Failed to post, please try again!");
    }
    }
}
