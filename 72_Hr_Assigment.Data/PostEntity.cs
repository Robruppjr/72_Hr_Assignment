using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PostEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Text { get; set; }

}
