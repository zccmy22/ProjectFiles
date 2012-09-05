using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Account.Entity;

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
        public Base_t_AccountScurityInfoEntity SelectScurityInfo(int sId)
        {
            return null;
        }
        /// <summary>
        /// 验证手机信息
        /// </summary>
        /// <param name="telNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateTel(string telNo, int accountId, out string message)
        {
            message = "";
            return true;
        }
        /// <summary>
        /// 验证邮箱信息
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email, int accountId, out string message)
        {
            message = "";
            return true;
        }
        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="accountId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool UpdatePayPassword(string oldPassword, string newPassword, int accountId, out string message)
        {
            message = "";
            return true;
        }
    }
}
