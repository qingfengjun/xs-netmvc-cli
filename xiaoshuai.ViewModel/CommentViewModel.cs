using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xiaoshuai.ViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string ArticleId { get; set; }
        public string Comment { get; set; }
        public string IPAdress { get; set; }
        public string Name { get; set; }
        public string UserImg { get; set; }
        public string UserUrl { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
