using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace advokatplus.Models.Posts
{
    public class Post
    {
        public int PostID { get; set; }

        [Display(Name = "Заголовок")]
        public string PostName { get; set; }

        [Display(Name = "Описание")]
        public string PostDiscription { get; set; }

        [Display(Name = "Пост")]
        public string PostContent { get; set; }

        public DateTime TimeStamp { get; set; }
        public Post()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
