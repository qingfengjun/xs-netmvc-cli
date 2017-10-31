using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xiaoshuai.Common
{
    public class MailHelper
    {
        public static bool Send(MailDto dto)
        {
            //简单邮件传输协议类
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.163.com";//邮件服务器
            client.Port = 25;//smtp主机上的端口号,默认是25.
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;//邮件发送方式:通过网络发送到SMTP服务器
            client.Credentials = new System.Net.NetworkCredential("xshuai1992", "xiaoshuai");//凭证,发件人登录邮箱的用户名和密码

            //电子邮件信息类
            System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("xshuai1992@163.com");//发件人Email,在邮箱是这样显示的,[发件人:小明<panthervic@163.com>;]
            System.Net.Mail.MailAddress toAddress = new System.Net.Mail.MailAddress("491621884@qq.com", "小红");//收件人Email,在邮箱是这样显示的, [收件人:小红<43327681@163.com>;]
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(fromAddress, toAddress);//创建一个电子邮件类
            mailMessage.Subject = "【xiaoshuai】" + dto.Subject;
            string mailBody = dto.Body;
            mailMessage.Body = mailBody;//可为html格式文本
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;//邮件主题编码
            mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//邮件内容编码
            mailMessage.IsBodyHtml = true;//邮件内容是否为html格式
            mailMessage.Priority = System.Net.Mail.MailPriority.High;//邮件的优先级,有三个值:高(在邮件主题前有一个红色感叹号,表示紧急),低(在邮件主题前有一个蓝色向下箭头,表示缓慢),正常(无显示).

            bool result = false;
            try
            {
                // client.Send(mailMessage);//发送邮件
                client.SendAsync(mailMessage, "ojb");//异步方法发送邮件,不会阻塞线程.
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
    public class MailDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
