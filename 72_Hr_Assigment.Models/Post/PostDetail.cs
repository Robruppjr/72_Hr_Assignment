using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class PostDetail
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public List<CommentEntity> Comments {get;set;}
    }
