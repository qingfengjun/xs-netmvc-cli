using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace xiaoshuai.Repository.Entity
{
    [Table("Article")]
    public class ArticleEntity
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int IsTop { get; set; }
        public string ArticleId { get; set; }
    }
}
