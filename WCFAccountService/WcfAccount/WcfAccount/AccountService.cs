using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Account.Entity;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;


namespace WcfAccount
{
    // 注意: 如果更改此处的类名 "AccountService"，也必须更新 App.config 中对 "AccountService" 的引用。
    public class AccountService : IAccountService
    {
        /// <summary>
        /// 新增账户信息
        /// </summary>
        /// <param name="baie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool AddAccountInfo(Base_t_AccountInfoEntity baie, out string message)
        {
            message = "";
            return true;
        }

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
        /// 新增余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool AddBalance(decimal balance, int accountId, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// 扣减余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SubtractBalance(decimal balance, int accountId, out string message)
        {
            message = "";
            return true;
        }
        /// <summary>
        /// 查询账户信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public Base_t_AccountInfoEntity SelectAccountInfo(int accountId)
        {
            return null;
        }

        /// <summary>
        /// 更新账户信息
        /// </summary>
        /// <param name="baie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool UpdateAccountInfo(Base_t_AccountInfoEntity baie, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// 修改余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool UpdateBalance(decimal balance, int accountId, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// 新增待审核操作账户余额信息
        /// </summary>
        /// <param name="baaie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool AddAuditOperBalanceInfo(Base_t_AccountAuditInfoEntity baaie, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// 审核待审核记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        public bool AuditOperBalanceInfo(int auditId)
        {
            return true;
        }
        /// <summary>
        /// 查询待审核账户余额申请记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        public Base_t_AccountAuditInfoEntity SelectAccountAuditInfo(int auditId)
        {
            return null;
        }
    }
}
