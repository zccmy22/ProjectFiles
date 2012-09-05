using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Common;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using Account.Entity;

namespace WcfAccount
{
    [ServiceContract]
    public interface IAccountScurityService
    {
        /// <summary>
        /// 查询安全信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        [OperationContract]
        Base_t_AccountScurityInfoEntity SelectScurityInfo(int accountId);
        /// <summary>
        /// 验证手机信息
        /// </summary>
        /// <param name="telNo">手机号码</param>
        /// <param name="message">返回信息</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="validateCode">验证码</param>
        /// <returns></returns>
        [OperationContract]
        bool ValidateTel(string telNo, string validateCode, int accountId, out string message);
        /// <summary>
        /// 验证邮箱信息
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <param name="message">返回信息</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="validateCode">验证码</param>
        /// <returns></returns>
        [OperationContract]
        bool ValidateEmail(string email, string validateCode, int accountId, out string message);
        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdatePayPassword(string oldPassword, string newPassword, string scurityKey, int accountId, out string message);

        /// <summary>
        /// 重置支付密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool SetPayPassword(string newPassword, string scurityKey, int accountId, out string message);

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="Password">密码</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool ValidatePayPassword( string password, int accountId, out string message);

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
        [OperationContract]
        bool SendEmail(string from, string to, string subject, bool isBodyHtml, string body, string smtpHost, string userName, string password, out string message);

        /// <summary>
        /// 更新账户安全信息
        /// </summary>
        /// <param name="baie">账户安全信息实体</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateAccountScurityInfo(Base_t_AccountScurityInfoEntity baie);

        /// <summary>
        /// 邮箱是否唯一
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <returns></returns>
        [OperationContract]
        bool IsOnlyOneEmail(string email);

        /// <summary>
        /// 新增账户安全信息
        /// </summary>
        /// <param name="basie">安全信息实体</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertAccountScurityInfo(Base_t_AccountScurityInfoEntity basie, out string message);

        /// <summary>
        /// 更新账户邮箱安全信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="email">邮箱地址</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateAccountScurityEmailInfo(string email, int accountId, out string message);

        /// <summary>
        /// 更新账户手机安全信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="tel">手机号码</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateAccountScurityTelInfo(string tel, int accountId, out string message);

    }
}
