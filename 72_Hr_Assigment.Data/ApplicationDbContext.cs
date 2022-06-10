using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _72_Hr_Assigment.Data.Entities;
using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<CommentEntity> Comment {get;set;}


        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<ReplyEntity> Replies {get; set;}

    }
