using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace xiaoshuai.ViewModel
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string CategoryRemark { get; set; }

        [StringLength(2)]
        public int SortId { get; set; }

        public string CategoryId { get; set; }
    }
}
