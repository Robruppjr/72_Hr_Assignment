using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _72_Hr_Assigment.Models.Reply
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Text { get; set; }
    }
}