using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xiaoshuai.Common
{
    /// <summary>
    /// 生成唯一ID，方便数据迁移
    /// </summary>
    public class IDHelper
    {

        public static string Create(string prefix)
        {
            if (prefix.Length > 6)
            {
                throw new Exception("前缀长度过长");
            }
            return prefix + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
    }
}
