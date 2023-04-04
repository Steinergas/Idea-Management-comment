using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Idea_Management.Models
{
    public class post
    {
        [Key]
        public int post_id { get; set; }
        public string post_text { get; set; }
        public DateTime post_date { get; set; }
        public int post_like { get; set; }
        public int post_dislike { get; set; }

        public virtual Ideas Ideas { get; set; }
        public int IdeaId { get; set; }
    }
}