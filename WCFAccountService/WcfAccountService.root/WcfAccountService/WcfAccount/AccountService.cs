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
using Account.Business;


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
        public bool InsertAccountInfo(Base_t_AccountInfoEntity baie, out string accountId, out string message)
        {
            return AccountBusiness.InsertAccountInfo(baie, out accountId, out message);
        }

        
        /// <summary>
        /// 新增余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool AddBalance(decimal balance, int accountId, out string message)
        {
            return AccountBusiness.AddBalance(balance, accountId, out message);
        }

        /// <summary>
        /// 扣减余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SubtractBalance(decimal balance, int accountId, out string message)
        {
            return AccountBusiness.SubtractBalance(balance, accountId, out message);
        }
        /// <summary>
        /// 查询账户信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public Base_t_AccountInfoEntity SelectAccountInfo(int accountId)
        {
            return AccountBusiness.SelectAccountInfo(accountId);
        }

        /// <summary>
        /// 更新账户信息
        /// </summary>
        /// <param name="baie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool UpdateAccountInfo(Base_t_AccountInfoEntity baie, out string message)
        {
            return AccountBusiness.UpdateAccountInfo(baie, out message);
        }

        /// <summary>
        /// 修改余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool UpdateBalance(decimal balance, int accountId, out string message)
        {
            return AccountBusiness.UpdateBalance(balance, accountId, out message);
        }

        /// <summary>
        /// 新增待审核操作账户余额信息
        /// </summary>
        /// <param name="baaie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool InsertAuditOperBalanceInfo(Base_t_AccountAuditInfoEntity baaie, out string message)
        {
            return AccountBusiness.InsertAuditOperBalanceInfo(baaie, out message);
        }

         /// <summary>
        /// 新增账户流水信息
        /// </summary>
        /// <param name="baaie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool InsertOperBalanceInfo(Base_t_AccountDetailEntity bade, out string message)
        {
            return AccountBusiness.InsertOperBalanceInfo(bade, out  message);
        }

        /// <summary>
        /// 审核待审核记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        public bool AuditOperBalanceInfo(int auditId, string operUserId, bool status,out string message)
        {
            return AccountBusiness.AuditOperBalanceInfo(auditId, operUserId, status, out message);
        }
        /// <summary>
        /// 查询待审核账户余额申请记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        public Base_t_AccountAuditInfoEntity SelectAccountAuditInfo(int auditId)
        {
            return AccountBusiness.SelectAccountAuditInfo(auditId);
        }

        /// <summary>
        /// 根据账户ID和时间查询账户待审核信息
        /// </summary>
        /// <param name="AccountAuditInfo">账户实例</param>
        /// <param name="starTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<Base_t_AccountAuditInfoEntity> SelectAccountAuditInfoByTime(Base_t_AccountAuditInfoEntity AccountAuditInfo, DateTime starTime, DateTime endTime, int pageSize, int pageNumber, out int recordCount)
        {
            return AccountBusiness.SelectAccountAuditInfoByTime(AccountAuditInfo, starTime, endTime, pageSize, pageNumber, out recordCount);
        }

        /// <summary>
        /// 根据账户ID和时间查询账户流水信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="starTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<Base_t_AccountDetailEntity> SelectAccountDetailInfoByTime(int accountId, string starTime, string endTime, int pageSize, int pageNumber, out int recordCount)
        {
            return AccountBusiness.SelectAccountDetailInfoByTime(accountId, starTime, endTime, pageSize, pageNumber, out recordCount);
        }

        /// <summary>
        /// 根据账户ID和时间查询账户信息
        /// </summary>
        /// <param name="email">邮件</param>
        /// <param name="message"> 返回信息 </param>
        /// <param name="tel">电话</param>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public List<Base_t_AccountInfoEntity> SelectAccountInfoByAllInfo(string userids, string email, string tel, out string message)
        {
            return AccountBusiness.SelectAccountInfoByAllInfo(userids , email, tel, out message);
        }

        /// <summary>
        /// 根据用户ID查询账户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public Base_t_AccountInfoEntity SelectAccountInfoByUserId(string userId)
        {
            return AccountBusiness.SelectAccountInfoByUserId( userId );
        }



        /// <summary>
        ///  锁定账户信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="mark">操作描述说明</param>
        /// <param name="operId">操作ID</param>
        /// <param name="subjecId">操作子系统编码</param>
        /// <returns></returns>
        public bool BlockAccountInfo(int accountId, string userCode, string userName, string operId, string mark, string subjecCode, out string message)
        {
            return AccountBusiness.BlockAccountInfo(accountId, userCode, userName, operId, mark, subjecCode, out message);
        }

        /// <summary>
        /// 解锁账户信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="mark">操作描述说明</param>
        /// <param name="operId">操作ID</param>
        /// <param name="subjecId">操作子系统编码</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        public bool UnBlockAccountInfo(int accountId, string userCode, string userName, string operId, string mark, string subjecCode, out string message)
        {
            return AccountBusiness.UnBlockAccountInfo(accountId,userCode, userName, operId, mark, subjecCode, out message);
        }

        /// <summary>
        ///  锁定账户余额
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="mark">操作描述说明</param>
        /// <param name="operId">操作ID</param>
        /// <param name="subjecId">操作子系统编码</param>
        /// <param name="balance">余额</param>
        /// <param name="message">反回信息</param>
        /// <returns></returns>
        public bool BlockAccountBalance(int accountId, string operId, string mark, string subjecCode, decimal balance, out string message)
        {
            return AccountBusiness.BlockAccountBalance(accountId, operId, mark, subjecCode, balance, out message);
        }

        /// <summary>
        ///  锁定账户余额
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="mark">操作描述说明</param>
        /// <param name="operId">操作ID</param>
        /// <param name="subjecId">操作子系统编码</param>
        /// <param name="balance">余额</param>
        /// <param name="message">反回信息</param>
        /// <returns></returns>
        public bool UnBlockAccountBalance(int accountId, string operId, string mark, string subjecCode, decimal balance, out string message)
        {
            return AccountBusiness.UnBlockAccountBalance(accountId, operId, mark, subjecCode, balance, out message);
        }

        /// <summary>
        /// 查询所有账户信息
        /// </summary>
        /// <returns></returns>
        public List<Base_t_AccountDetailEntity> SelectAllAccountDetailInfoByTime(int accountId, string starTime, string endTime)
        {
            return AccountBusiness.SelectAllAccountDetailInfoByTime(accountId, starTime, endTime);
        }

    }
}
