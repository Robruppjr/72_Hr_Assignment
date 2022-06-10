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
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        public List<ReplyEntity> Replies {get; set;}
        // public Guid AuthorId { get; set; }
    }
