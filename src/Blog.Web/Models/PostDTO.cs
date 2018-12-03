using System;
using System.Collections.Generic;

namespace Blog.Web.Models
{
    public class PostDTO
    {
        public PostDTO()
        {
            Comments = new List<CommentDTO>();
        }

        public int PostId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public IList<CommentDTO> Comments { get; set; }
    }
}
