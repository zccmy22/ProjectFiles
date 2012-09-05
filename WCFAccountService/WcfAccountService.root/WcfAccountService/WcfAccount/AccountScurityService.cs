using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Account.Entity;
using Account.Business;

namespace WcfAccount
{
    // 注意: 如果更改此处的类名 "AccountScurityService"，也必须更新 App.config 中对 "AccountScurityService" 的引用。
    public class AccountScurityService : IAccountScurityService
    {
        /// <summary>
        /// 查询安全信息
        /// </summary>
        /// <param name="sId"></param>
        /// <returns></returns>
        public Base_t_AccountScurityInfoEntity SelectScurityInfo(int accountId)
        {
            return AccountScurityBusiness.SelectScurityInfo(accountId);
        }
        /// <summary>
        /// 验证手机信息
        /// </summary>
        /// <param name="telNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateTel(string telNo, string validateCode, int accountId, out string message)
        {
            return AccountScurityBusiness.ValidateTel(telNo, validateCode, accountId, out message);
        }
        /// <summary>
        /// 验证邮箱信息
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email, string validateCode, int accountId, out string message)
        {
            return AccountScurityBusiness.ValidateEmail(email, validateCode, accountId, out message);
        }
        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="accountId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool UpdatePayPassword(string oldPassword, string newPassword, string scurityKey, int accountId, out string message)
        {
            return AccountScurityBusiness.UpdatePayPassword(oldPassword, newPassword, scurityKey, accountId, out message);
        }

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="Password">密码</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        public bool ValidatePayPassword(string password, int accountId, out string message)
        {
            return AccountScurityBusiness.ValidatePayPassword(password, accountId, out message);
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
        public bool SendEmail(string from, string to, string subject, bool isBodyHtml, string body, string smtpHost, string userName, string password, out string message)
        {
            return AccountScurityBusiness.SendEmail(from, to, subject, isBodyHtml, body, smtpHost, userName, password, out message);
        }

        /// <summary>
        /// 更新账户安全信息
        /// </summary>
        /// <param name="baie">账户安全信息实体</param>
        /// <returns></returns>
        public bool UpdateAccountScurityInfo(Base_t_AccountScurityInfoEntity baie)
        {
            return AccountScurityBusiness.UpdateAccountScurityInfo(baie);
        }

        /// <summary>
        /// 邮箱是否唯一
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <returns></returns>
        public bool IsOnlyOneEmail(string email)
        {
            return AccountScurityBusiness.IsOnlyOneEmail(email);
        }


        /// <summary>
        /// 新增账户安全信息
        /// </summary>
        /// <param name="basie">安全信息实体</param>
        /// <returns></returns>
        public bool InsertAccountScurityInfo(Base_t_AccountScurityInfoEntity basie, out string message)
        {
            return AccountScurityBusiness.InsertAccountScurityInfo(basie,out message);
        }
        /// <summary>
        /// 更新账户邮箱安全信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="email">邮箱地址</param>
        /// <returns></returns>
        public bool UpdateAccountScurityEmailInfo(string email, int accountId, out string message)
        {
            return AccountScurityBusiness.UpdateAccountScurityEmailInfo(email, accountId, out message);
        }

        /// <summary>
        /// 更新账户手机安全信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="tel">手机号码</param>
        /// <returns></returns>
        public bool UpdateAccountScurityTelInfo(string tel, int accountId, out string message)
        {
            return AccountScurityBusiness.UpdateAccountScurityTelInfo(tel, accountId,out message);
        }

        /// <summary>
        /// 重置支付密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        public bool SetPayPassword(string newPassword, string scurityKey, int accountId, out string message)
        {
            return AccountScurityBusiness.SetPayPassword(newPassword, scurityKey, accountId, out message);
        }
    }
}
