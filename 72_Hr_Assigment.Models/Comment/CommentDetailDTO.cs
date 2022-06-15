using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class CommentDetailDTO
    {
        public int Id {get;set;}
        public string Text {get;set;}
        
        public int PostId {get;set;}
        public List<ReplyEntity> Replies {get;set;}
    }
