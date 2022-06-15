using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


   
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
      

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //Get by post id
        //get

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreateDTO request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _commentService.CreateCommentAsync(request))
            {
                return Ok("Comment was created.");
            }

            return BadRequest("Comment could not be created.");

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsByPost([FromRoute] int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
           
           return comments is not null
            ? Ok(comments)
            : NotFound();

        }
        

        [HttpPut]
        public async Task<IActionResult> UpdateCommentById([FromBody] CommentEditDTO request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                return await _commentService.UpdateCommentAsync(request) 
                    ? Ok("Comment was updated.") : BadRequest("Comment could not be updated.");
        }
        

        [HttpDelete]
        [Route("{commentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
        {
            return await  _commentService.DeleteCommentAsync(commentId) 
                ? Ok($"Comment {commentId} was deleted.") : BadRequest($"Comment {commentId} could not be deleted");
        }
        
    }
