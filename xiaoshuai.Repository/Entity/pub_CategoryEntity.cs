using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace xiaoshuai.Repository.Entity
{
    [Table("pub_Category")]
    public class pub_CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryRemark { get; set; }
        public int SortId { get; set; }
        public string CategoryId { get; set; }
    }
}
