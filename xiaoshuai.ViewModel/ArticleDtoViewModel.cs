using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xiaoshuai.ViewModel
{
    public class ArticleDtoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string ArticleId { get; set; }
    }
}
