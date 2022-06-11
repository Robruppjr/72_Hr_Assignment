using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class ReplyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public CommentEntity Comment{get; set;}
        public string Text { get; set; }
        // public List<ReplyEntity> Replies {get; set;}
        // public Guid AuthorId { get; set; }
    }
