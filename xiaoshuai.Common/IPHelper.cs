using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace xiaoshuai.Common
{
    public class IPHelper
    {
        public static string GetIp()
        {
            //获取本机外网IP地址
            HttpRequest request = HttpContext.Current.Request;
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                result = "0.0.0.0";
            }
            return result;

        }

        ///
        /// 根据IP获取省市
        ///
        public static string GetAddressByIp(string ip)
        {
            string PostUrl = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?ip=" + ip;
            string res = GetDataByPost(PostUrl);//该条请求返回的数据为：res=1\t115.193.210.0\t115.194.201.255\t中国\t浙江\t杭州\t电信
            string[] arr = getAreaInfoList(res);
            return arr[1] == null ? "游客" : arr[1].ToString().Trim();
        }
        ///
        /// Post请求数据
        ///
        ///
        ///
        public static string GetDataByPost(string url)
        {
            string result = string.Empty;
            HttpWebRequest request = null;
            WebResponse response = null;
            StreamReader streamReader = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Proxy = null;
                request.Timeout = 500;
                request.AllowAutoRedirect = true;

                byte[] bs = Encoding.ASCII.GetBytes("anything");
                string responseData = String.Empty;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bs.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }
            }

            return result;

        }
        ///
        /// 处理所要的数据
        ///
        ///
        ///
        public static string[] getAreaInfoList(string ipData)
        {
            //1\t115.193.210.0\t115.194.201.255\t中国\t浙江\t杭州\t电信
            string[] areaArr = new string[10];
            string[] newAreaArr = new string[2];
            try
            {
                //取所要的数据，这里只取省市
                areaArr = ipData.Split('\t');
                newAreaArr[0] = areaArr[4];//省
                newAreaArr[1] = areaArr[5];//市
            }
            catch (Exception e)
            {
                // TODO: handle exception
                throw e;
            }
            return newAreaArr;
        }
    }
}
