using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xiaoshuai.ViewModel
{
    /// <summary>
    /// 下拉框view
    /// </summary>
    public class ComboxViewModel
    {
        public string Category { get; set; }
        public object Value { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// 是否勾选
        /// </summary>
        private bool _isSelect = false;
        public bool IsSelect
        {
            get { return _isSelect; }
            set { _isSelect = value; }
        }
    }
}
