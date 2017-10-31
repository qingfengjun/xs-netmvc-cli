using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xiaoshuai.ViewModel
{
    public class CategoryNavViewModel
    {
        public string categoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategoryNavViewModel> SubCategory { get; set; }
    }

    public class SubCategoryNavViewModel
    {
        public string SubCategoryId { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int ArticleNum { get; set; }
        public string Url { get; set; }
    }
}
