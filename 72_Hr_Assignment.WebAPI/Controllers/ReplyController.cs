using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Models.Reply;
using _72_Hr_Assigment.Service.Reply;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _72_Hr_Assignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;
        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }
        
        // [HttpGet]
        // public async Task<IActionResult> GetAllReplies()
        // {
        //     var replies = await _replyService.GetAllRepliesAsync();
        //     return Ok(replies);
        // }
        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] ReplyCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _replyService.CreateReplyAsync(request))
                return Ok("Reply was created succesfully.");
            
            return BadRequest("Note could not be created.");
        }
        //Get api/Reply/(commentId)
        [HttpGet("{commentId:int}")]
        public async Task<IActionResult> GetReplyByComenntId([FromRoute] int ownerId)
        {
            var detail = await _replyService.GetReplyByCommentIdAsync(ownerId);

            return detail is not null
                ? Ok(detail)
                : NotFound();
        }
    }
}
