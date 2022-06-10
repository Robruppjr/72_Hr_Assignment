using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


   
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ApplicationDbContext _context;

        public CommentController(ILogger<CommentController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

      
       
    }
