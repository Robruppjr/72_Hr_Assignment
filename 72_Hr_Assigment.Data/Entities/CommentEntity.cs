using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class CommentEntity
    {
        [Key]
        public int Id {get;set;}

        public string Text {get;set;}

    }
