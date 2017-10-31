using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xiaoshuai.Repository.DTO
{
    public class SubCategoryDto
    {
        public string SubCategoryId { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int ArticleNum { get; set; }
        public string ArticleId { get; set; }
    }
}
