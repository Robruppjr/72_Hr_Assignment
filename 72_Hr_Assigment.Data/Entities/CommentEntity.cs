using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class CommentEntity
    {
        [Key]
        public int Id {get;set;}

        [Required]
        public string Text {get;set;}

        [ForeignKey(nameof(Post))]
       
        public int PostId {get;set;}
        public virtual PostEntity Post {get; set;}
        public virtual List<ReplyEntity> Replies {get; set;}

    }