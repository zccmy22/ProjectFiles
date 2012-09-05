using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
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
        /// <param name="sId"></param>
        /// <returns></returns>
        [OperationContract]
        Base_t_AccountScurityInfoEntity SelectScurityInfo(int sId);
        /// <summary>
        /// 验证手机信息
        /// </summary>
        /// <param name="telNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool ValidateTel(string telNo, int accountId, out string message);
        /// <summary>
        /// 验证邮箱信息
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool ValidateEmail(string email, int accountId, out string message);
        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="accountId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdatePayPassword(string oldPassword, string newPassword, int accountId, out string message);


    }
}
