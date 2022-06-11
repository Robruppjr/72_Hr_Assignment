using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;
        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }
        //Get api/Note
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
    }

