using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Service.Reply;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _72_Hr_Assignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _service;
        public ReplyController(IReplyService services)
        {
            _service = services;
        }
        // [HttpPost]
        // public async Task<IActionResult> CreateReply([FromBody] ReplyCreate request)
        // {
        //     if (!ModelState.IsValid)
        // }
    }
}
