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
using System.ServiceModel.Web;

namespace WcfAccount
{
    // 注意: 如果更改此处的接口名称“IService1”，也必须更新 App.config 中对“IService1”的引用。
    [ServiceContract]
    public interface IAccountService
    {
        /// <summary>
        /// 新增账户信息
        /// </summary>
        /// <param name="baie">账户实体</param>
        /// <param name="message">返回错误信息</param>
        /// <param name="accountId">返回账户ID</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertAccountInfo(Base_t_AccountInfoEntity baie, out string accountId, out string message);
        /// <summary>
        /// 新增余额
        /// </summary>
        /// <param name="balance">新增加的金额 </param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool AddBalance(decimal balance, int accountId, out string message);
        /// <summary>
        /// 扣减余额
        /// </summary>
        /// <param name="balance">扣减的金额数</param>
        /// <param name="message">返回信息</param>
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
        /// <param name="baie">账户信息实体</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateAccountInfo(Base_t_AccountInfoEntity baie, out string message);

        /// <summary>
        ///  锁定账户信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="mark">操作描述说明</param>
        /// <param name="operId">操作ID</param>
        /// <param name="subjecId">操作子系统编码</param>
        /// <returns></returns>
        [OperationContract]
        bool BlockAccountInfo(int accountId, string userCode, string userName, string operId, string mark, string subjecCode, out string message);

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
        [OperationContract]
        bool BlockAccountBalance(int accountId, string operId, string mark, string subjecCode,decimal balance, out string message);

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
        [OperationContract]
        bool UnBlockAccountBalance(int accountId, string operId, string mark, string subjecCode, decimal balance, out string message);

        /// <summary>
        /// 解锁账户信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="mark">操作描述说明</param>
        /// <param name="operId">操作ID</param>
        /// <param name="subjecId">操作子系统编码</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool UnBlockAccountInfo(int accountId, string userCode, string userName, string operId, string mark, string subjecCode, out string message);


        /// <summary>
        /// 修改余额
        /// </summary>
        /// <param name="balance">账户修改的金额</param>
        /// <param name="message">返回的错误信息</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateBalance(decimal balance, int accountId, out string message);

        /// <summary>
        /// 新增待审核操作账户余额信息
        /// </summary>
        /// <param name="baaie">账户审核表信息实体</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertAuditOperBalanceInfo(Base_t_AccountAuditInfoEntity baaie, out string message);

        /// <summary>
        /// 审核待审核记录
        /// </summary>
        /// <param name="auditId">审核信息ID</param>
        /// <param name="operUserId">审核员ID</param>
        /// <param name="status">审核状态</param>
        /// <returns></returns>
        [OperationContract]
        bool AuditOperBalanceInfo(int auditId, string operUserId, bool status, out string message);
        /// <summary>
        /// 查询待审核账户余额申请记录
        /// </summary>
        /// <param name="auditId">审核信息ID</param>
        /// <returns></returns>
        [OperationContract]
        Base_t_AccountAuditInfoEntity SelectAccountAuditInfo(int auditId);

        /// <summary>
        /// 根据账户ID和时间查询账户待审核信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="starTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        List<Base_t_AccountAuditInfoEntity> SelectAccountAuditInfoByTime(Base_t_AccountAuditInfoEntity AccountAuditInfo, DateTime starTime, DateTime endTime, int pageSize, int pageNumber, out int recordCount);

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
        [OperationContract]
        List<Base_t_AccountDetailEntity> SelectAccountDetailInfoByTime(int accountId, string starTime, string endTime, int pageSize, int pageNumber, out int recordCount);

        /// <summary>
        /// 根据账户ID和时间查询账户信息
        /// </summary>
        /// <param name="email">邮件</param>
        /// <param name="message"> 返回信息 </param>
        /// <param name="tel">电话</param>
        /// <param name="userid">用户ID，可以是多个，用“，”间隔</param>
        /// <returns></returns>
        [OperationContract]
        List<Base_t_AccountInfoEntity> SelectAccountInfoByAllInfo(string userids, string email, string tel, out string message);

        /// <summary>
        /// 根据用户ID查询账户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        Base_t_AccountInfoEntity SelectAccountInfoByUserId(string  userId);
        
         /// <summary>
        /// 新增账户流水信息
        /// </summary>
        /// <param name="baaie">流水实体</param>
        /// <param name="message">返回提示信息</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertOperBalanceInfo(Base_t_AccountDetailEntity bade, out string message);

        /// <summary>
        /// 查询时间内账户流水信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="starTime">起始时间</param>
        /// <param name="endTime"> 结止时间</param>
        /// <returns></returns>
        [OperationContract]
        List<Base_t_AccountDetailEntity> SelectAllAccountDetailInfoByTime(int accountId, string starTime, string endTime);

    }
}
