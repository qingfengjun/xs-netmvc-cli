using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace xiaoshuai.Repository.Entity
{
    [Table("pub_SubCategory")]
    public class pub_SubCategoryEntity
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryRemark { get; set; }
        public string SubCategoryId { get; set; }
        public int SortId { get; set; }
    }
}
