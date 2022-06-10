using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<CommentEntity> Comment {get;set;}

<<<<<<< HEAD
            public DbSet<ReplyEntity> Replies {get; set;}
=======

        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<ReplyEntity> Replies {get; set;}
>>>>>>> 9a37a717b6b60f87998d51c212f9edc1f1c7b93d

    }
