using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using System.Net.Mail;

namespace Account.Common
{
    public class PublicFunction
    {
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <typeparam name="T">业务实体</typeparam>
        /// <param name="from">源实例</param>
        /// <param name="to">目标实例</param>
        private static void CopyObject<T1, T2>(T1 from, T2 to)
        {

            PropertyInfo[] fieldsFrom = from.GetType().GetProperties();
            PropertyInfo[] fieldsTo = to.GetType().GetProperties();

            foreach (PropertyInfo fieldFrom in fieldsFrom)
            {
                Object obj = fieldFrom.GetValue(from, null);
                foreach (PropertyInfo fieldTo in fieldsTo)
                {
                    if (fieldTo.Name == fieldFrom.Name)
                    {
                        fieldTo.SetValue(to, obj, null);
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="txtEncrypt">加密字符串</param>
        /// <param name="number">固定入参16,密码截取前16位</param>
        /// <returns>密文</returns>
        public static string MD5Encrypt(string txtEncrypt, int number)
        {
            byte[] buffer1 = Encoding.Default.GetBytes(txtEncrypt);
            buffer1 = new MD5CryptoServiceProvider().ComputeHash(buffer1);
            string text1 = "";
            for (int num1 = 0; num1 < buffer1.Length; num1++)
            {
                text1 = text1 + buffer1[num1].ToString("x").PadLeft(2, '0');
            }
            if (number == 0x10)
            {
                return text1.Substring(8, 0x10);
            }
            return text1;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="from">发送人邮件地址</param>
        /// <param name="to">接收人邮件地址</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="isBodyHtml">是否是Html</param>
        /// <param name="body">邮件体</param>
        /// <param name="smtpHost">SMTP服务器地址</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>是否成功</returns>
        public static bool Send(string from, string to, string subject, bool isBodyHtml, string body, string smtpHost, string userName, string password, out string message)
        {
            message = "";
            string[] ts = to.Split(',');
            bool isSuccess = true;
            foreach (string t in ts)
            {
                try
                {
                    MailMessage mm = new MailMessage();
                    mm.From = new MailAddress(from);

                    mm.To.Add(new MailAddress(t.Trim()));

                    mm.Subject = subject;
                    mm.IsBodyHtml = isBodyHtml;
                    mm.Body = body;

                    SmtpClient sc = new SmtpClient();
                    sc.Host = smtpHost;

                    sc.UseDefaultCredentials = true;//winform中不受影响，asp.net中，false表示不发送身份严正信息
                    //smtpClient.EnableSsl = true;//如果服务器不支持ssl则报，服务器不支持安全连接 错误
                    sc.Credentials = new System.Net.NetworkCredential(userName, password);
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;

                    sc.Send(mm);
                    message = "发送成功";
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                    isSuccess = false;
                }
            }
            return isSuccess;
        }


        /// <summary>
        /// 对象 数据 拷贝
        /// </summary>
        /// <param name="source">源对象</param>
        /// <param name="destination">目的对象</param>
        /// <returns>是否有异常</returns>
        public static bool ObjectCopyTo(object source, object destination)
        {
            bool rel = true;
            if (destination == null)
            {
                throw new Exception("目标对象未初始化！");
            }
            PropertyInfo[] _sourceProperties = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] _destinationProperties = destination.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo sourcePropertie in _sourceProperties)
            {
                foreach (PropertyInfo destinationProperty in _destinationProperties)
                {
                    if (sourcePropertie.Name.ToLower().Equals(destinationProperty.Name.ToLower()))
                    {
                        try
                        {
                            destinationProperty.SetValue(destination, sourcePropertie.GetValue(source, null), null);
                            break;
                        }
                        catch
                        {
                            rel = false;
                        }
                    }
                }
            }
            return rel;
        }

    }
}
