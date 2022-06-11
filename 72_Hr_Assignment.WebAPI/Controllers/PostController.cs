using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

         public PostController(IPostService postService)
        {
            _postService = postService;
        }
       
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _postService.CreatePostAsync(request))
            {
                return Ok("Post was created.");
            }

            return BadRequest("Post could not be created.");

        }
    }

