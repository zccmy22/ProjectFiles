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
    // 注意: 如果更改此处的接口名称“IService1”，也必须更新 App.config 中对“IService1”的引用。
    [ServiceContract]
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        string GetData(int value);
        /// <summary>
        /// 新增账户信息
        /// </summary>
        /// <param name="baie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddAccountInfo(Base_t_AccountInfoEntity baie , out string message );
        /// <summary>
        /// 新增余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddBalance(decimal balance, int accountId, out string message);
        /// <summary>
        /// 扣减余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool SubtractBalance(decimal balance, int accountId, out string message);
        /// <summary>
        /// 查询账户信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [OperationContract]
        Base_t_AccountInfoEntity SelectAccountInfo(int accountId);
        
        /// <summary>
        /// 更新账户信息
        /// </summary>
        /// <param name="baie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateAccountInfo(Base_t_AccountInfoEntity baie, out string message);

        /// <summary>
        /// 修改余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateBalance(decimal balance, int accountId, out string message);

        /// <summary>
        /// 新增待审核操作账户余额信息
        /// </summary>
        /// <param name="baaie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddAuditOperBalanceInfo(Base_t_AccountAuditInfoEntity baaie, out string message);

        /// <summary>
        /// 审核待审核记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        [OperationContract]
        bool AuditOperBalanceInfo(int auditId );
        /// <summary>
        /// 查询待审核账户余额申请记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        [OperationContract]
        Base_t_AccountAuditInfoEntity SelectAccountAuditInfo(int auditId);

    }
}
