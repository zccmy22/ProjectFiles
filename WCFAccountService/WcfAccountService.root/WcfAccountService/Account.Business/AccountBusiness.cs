using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Account.Entity;
using Account.Data;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using Account.Common;
using System.Data.Common;

namespace Account.Business
{
    public class AccountBusiness
    {
        /// <summary>
        /// 新增账户信息
        /// </summary>
        /// <param name="baie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool InsertAccountInfo(Base_t_AccountInfoEntity baie, out string accountId, out string message)
        {
            accountId = "";
            bool retFlag = false;

            Base_t_AccountInfo adbai = new Base_t_AccountInfo();

            if (baie == null)
            {
                message = "传入参数有误";
                return false;
            }
            //进行实体转换
            PublicFunction.ObjectCopyTo(baie, adbai);

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            try
            {
                if (adbai != null)
                { 
                    adsdc.Base_t_AccountInfo.InsertOnSubmit(adbai);
                    adsdc.SubmitChanges();
                    
                }
                retFlag = true;
                message = "新增账户信息成功";
                //返回账户ID
                accountId = adbai.id.ToString();
            }
            catch(Exception ex)
            {
                retFlag = false;
                message = ex.Message;
            }
            return retFlag;
        }
        /// <summary>
        /// 新增余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool AddBalance(decimal balance, int accountId, out string message)
        {
            message = "";
            bool retFlag= false;  //返回结果
            Base_t_AccountInfo bai= new Base_t_AccountInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();

            bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p=>p.id == accountId);

            if(bai == null)
            {
                retFlag = false;
                message = "不存在该账户信息; accountId:"+accountId.ToString();
            }
            else
            {
                try
                {
                    bai.balance = bai.balance + balance;
                    adsdc.SubmitChanges();
                    retFlag = true;
                    message = "新增余额成功";
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                    retFlag = false;
                }
            }
            
            return retFlag;
        }

        /// <summary>
        /// 扣减余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SubtractBalance(decimal balance, int accountId, out string message)
        {
            message = "";
            bool retFlag = false;  //返回结果
            Base_t_AccountInfo bai = new Base_t_AccountInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();

            bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == accountId);

            if (bai == null)
            {
                retFlag = false;
                message = "不存在该账户信息; accountId:" + accountId.ToString();
            }
            else
            {
                try
                {
                    if (bai.balance - bai.blockBalance < balance)
                    {
                        message = "账户余额不足";
                        retFlag = false;
                    }
                    else
                    {
                        bai.balance = bai.balance - balance;
                        adsdc.SubmitChanges();
                        retFlag = true;
                        message = "扣余额成功";
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    retFlag = false;
                }
            }

            return retFlag;
        }
        /// <summary>
        /// 查询账户信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static Base_t_AccountInfoEntity SelectAccountInfo(int accountId)
        {
            Base_t_AccountInfo bai = new Base_t_AccountInfo();
            Base_t_AccountInfoEntity baie = new Base_t_AccountInfoEntity();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();

            bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == accountId);
            if (bai != null) 
                PublicFunction.ObjectCopyTo(bai, baie);
            if (baie != null)
            {
                return baie;
            }

            return null;
        }

        /// <summary>
        /// 查询账户信息
        /// </summary>
        /// <param name="starTime">起始时间</param>
        /// <param name="endTime"> 结止时间</param>
        /// <returns></returns>
        public static List<Base_t_AccountDetailEntity> SelectAllAccountDetailInfoByTime(int accountId, string starTime, string endTime)
        {
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                List<Base_t_AccountDetailEntity> badeList = new List<Base_t_AccountDetailEntity>();
                Base_t_AccountDetailEntity bade;
                List<Base_t_AccountDetail> badList = new List<Base_t_AccountDetail>();
                try
                {
                    var results = from C in adsdc.Base_t_AccountDetail select C;
                    if (accountId > 0)
                        results = results.Where(c => c.accountId == accountId);
                    if (!string.IsNullOrEmpty(starTime))
                        results = results.Where(c => c.opTime >= DateTime.Parse(starTime));
                    if (!string.IsNullOrEmpty(endTime))
                        results = results.Where(c => c.opTime <= DateTime.Parse(endTime).AddDays(1));
                    badList = results.OrderByDescending(c => c.opTime).ToList();
                    if (badList != null && badList.Count > 0)
                    {
                        foreach (Base_t_AccountDetail bad in badList)
                        {
                            bade = new Base_t_AccountDetailEntity();
                            PublicFunction.ObjectCopyTo(bad, bade);
                            if (bade != null)
                            {
                                badeList.Add(bade);
                            }
                        }
                    }

                    return badeList;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 更新账户信息
        /// </summary>
        /// <param name="baie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool UpdateAccountInfo(Base_t_AccountInfoEntity baie, out string message)
        {
            message = "";
            bool retFlag = false;
            Base_t_AccountInfo bai = new Base_t_AccountInfo();

            //转换实体
            if (baie != null && baie.Id > 0)
            {
                AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
                bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == baie.Id);
                
                PublicFunction.ObjectCopyTo(baie, bai);
                try
                {
                    adsdc.SubmitChanges();
                    message = "更新成功";
                    retFlag = true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    retFlag = false;
                }
            }

            return retFlag;
        }

        /// <summary>
        /// 修改余额
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool UpdateBalance(decimal balance, int accountId, out string message)
        {
            message = "";
            bool retFlag = false;  //返回结果
            Base_t_AccountInfo bai = new Base_t_AccountInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();

            bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == accountId);

            if (bai == null)
            {
                retFlag = false;
                message = "不存在该账户信息; accountId:" + accountId.ToString();
            }
            else
            {
                try
                {
                    bai.balance = balance;
                    adsdc.SubmitChanges();
                    retFlag = true;
                    message = "修改余额成功";
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    retFlag = false;
                }
            }

            return retFlag;
        }

        /// <summary>
        /// 新增待审核操作账户余额信息
        /// </summary>
        /// <param name="baaie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool InsertAuditOperBalanceInfo(Base_t_AccountAuditInfoEntity baaie, out string message)
        {

            bool retFlag = false;

            Base_t_AccountAuditInfo baai = new Base_t_AccountAuditInfo();

            //进行实体转换
            if(baaie != null)
                PublicFunction.ObjectCopyTo(baaie, baai);

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            try
            {
                if (baai != null)
                {
                    adsdc.Base_t_AccountAuditInfo.InsertOnSubmit(baai);
                    adsdc.SubmitChanges();

                }
                retFlag = true;
                message = "新增待审核信息成功";
                //返回账户ID
            }
            catch (Exception ex)
            {
                retFlag = false;
                message = ex.Message;
            }
            return retFlag;
        }

        /// <summary>
        /// 新增账户流水信息
        /// </summary>
        /// <param name="baaie"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool InsertOperBalanceInfo(Base_t_AccountDetailEntity bade, out string message)
        {
            message = "";
            bool retFlag = false;

            Base_t_AccountDetail bad = new Base_t_AccountDetail();
            
            //检查入参
            if (bade == null)
            {
                message = "传入参数有误";
                return false;
            }

            //进行实体转换
            PublicFunction.ObjectCopyTo(bade, bad);

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            try
            {
                if (bad != null)
                {
                    adsdc.Base_t_AccountDetail.InsertOnSubmit(bad);
                    adsdc.SubmitChanges();
                    retFlag = true;
                    message = "新增账户流水信息成功";

                }
                else
                {
                    message = "传入信息转换时出错";
                }
            }
            catch (Exception ex)
            {
                retFlag = false;
                message = ex.Message;
            }
            return retFlag;
        }


        /// <summary>
        /// 审核待审核记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        public static bool AuditOperBalanceInfo(int auditId, string operUserId,bool status, out string message)
        {
            message = "";
            bool retFlag = false;
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                DbTransaction tran = adsdc.Connection.BeginTransaction();
                Base_t_AccountAuditInfo baai = new Base_t_AccountAuditInfo();
                Base_t_AccountInfo bai = new Base_t_AccountInfo();
               
                baai = adsdc.Base_t_AccountAuditInfo.FirstOrDefault(p => p.id == auditId);
                try
                {
                    //审核待审核记录
                    if (baai != null)
                    {
                        //如果流水记如存在，则根据流水记录中的账户ID取账户信息
                        bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == baai.accountId);

                        baai.status = true;
                        baai.opUser = operUserId;
                        baai.opTime = DateTime.Now;
                        adsdc.SubmitChanges();
                        retFlag = true;
                    }

                    //审核成功，插入操作记录到流水记录表
                    if (retFlag)
                    {
                        string mess = "";
                        Base_t_AccountDetailEntity bade = new Base_t_AccountDetailEntity();
                        PublicFunction.ObjectCopyTo(baai, bade);

                        //自动赋值后，处理各别不同的属性值
                        bade.Id = 0;
                        bade.Orderid = baai.refId;
                        bade.Resume = baai.direction;
                        bade.UseBalance = (decimal)baai.opBalance;
                        if (baai.type == 0)
                            bade.EndBalance = (decimal)bai.balance + (decimal)baai.opBalance;
                        else
                            bade.EndBalance = (decimal)bai.balance - (decimal)baai.opBalance;

                        InsertOperBalanceInfo(bade, out mess);
                        message = mess;
                    }
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    message = ex.Message;
                    retFlag = false;
                }
            }
            return retFlag;
        }
        /// <summary>
        /// 查询待审核账户余额申请记录
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        public static Base_t_AccountAuditInfoEntity SelectAccountAuditInfo(int auditId)
        {
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                Base_t_AccountAuditInfo baai = new Base_t_AccountAuditInfo();
                Base_t_AccountAuditInfoEntity baaie = new Base_t_AccountAuditInfoEntity();
                baai = adsdc.Base_t_AccountAuditInfo.FirstOrDefault(p => p.id == auditId);
                if (baai != null)
                {
                    PublicFunction.ObjectCopyTo(baai, baaie);
                }
                else
                    return null;

                return baaie;
            }
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
        public static List<Base_t_AccountAuditInfoEntity> SelectAccountAuditInfoByTime(Base_t_AccountAuditInfoEntity AccountAuditInfo, DateTime starTime, DateTime endTime, int pageSize, int pageNumber, out int recordCount)
        {
            recordCount = 10;
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {

                List<Base_t_AccountAuditInfoEntity> baaieList = new List<Base_t_AccountAuditInfoEntity>();
                try
                {
                    var accountaudit = PredicateExtensions.True<Base_t_AccountAuditInfo>();
                    if (!string.IsNullOrEmpty(AccountAuditInfo.CustmerCode))
                    {
                        accountaudit = accountaudit.And(i => i.custmerCode.IndexOf(AccountAuditInfo.CustmerCode) != -1);
                    }
                    if (!string.IsNullOrEmpty(AccountAuditInfo.CustmerName))
                    {
                        accountaudit = accountaudit.And(i => i.custmerName.IndexOf(AccountAuditInfo.CustmerName) != -1);
                    }
                    if (starTime.Date != DateTime.MinValue)
                    {
                        accountaudit = accountaudit.And(i => i.createTime >= starTime.Date);
                    }
                    if (endTime.Date != DateTime.MinValue)
                    {
                        accountaudit = accountaudit.And(i => i.createTime <= endTime.Date);
                    }
                    accountaudit = accountaudit.And(i => i.status == false);
                    var results = from c in adsdc.Base_t_AccountAuditInfo.Where(accountaudit) 
                                  select new Base_t_AccountAuditInfoEntity
                                  {
                                      AccountId=Convert.ToInt32(c.accountId),
                                      CreateTime=c.createTime,
                                      CreateUser=c.createUser,
                                      CustmerCode=c.custmerCode,
                                      CustmerName=c.custmerName,
                                      CustmerType=Convert.ToInt32(c.custmerType),
                                      Direction=c.direction,
                                      Id=c.id,
                                      OpBalance=Convert.ToInt32(c.opBalance),
                                      OpTime=c.opTime,
                                      OpUser=c.opUser,
                                      RefId=c.refId,
                                      Remark=c.remark,
                                      Status=Convert.ToBoolean(c.status),
                                      SubjectCode=c.subjectCode,
                                      Type=Convert.ToInt32(c.type)
                                  };
                    List<Base_t_AccountAuditInfoEntity> baaiList = results.OrderByDescending(c => c.CreateTime).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                    return baaieList;
                }
                catch (System.Exception ex)
                {
                    recordCount = 0;
                    return null;
                }
            }
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
        public static List<Base_t_AccountDetailEntity> SelectAccountDetailInfoByTime(int accountId, string starTime, string endTime, int pageSize, int pageNumber, out int recordCount)
        {
            recordCount = 10;
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                List<Base_t_AccountDetailEntity> badeList = new List<Base_t_AccountDetailEntity>();
                Base_t_AccountDetailEntity bade;
                List<Base_t_AccountDetail> badList = new List<Base_t_AccountDetail>();
                try
                {
                    var results = from C in adsdc.Base_t_AccountDetail  select C;
                    if (accountId > 0)
                        results = results.Where(c => c.accountId == accountId);
                    if (!string.IsNullOrEmpty(starTime))
                        results = results.Where(c => c.opTime >= DateTime.Parse(starTime));
                    if (!string.IsNullOrEmpty(endTime))
                        results = results.Where(c => c.opTime <= DateTime.Parse(endTime).AddDays(1));
                    recordCount = results.Count();
                    badList = results.OrderByDescending(c => c.opTime).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                    if (badList != null && badList.Count > 0)
                    {
                        foreach (Base_t_AccountDetail bad in badList)
                        {
                            bade = new Base_t_AccountDetailEntity();
                            PublicFunction.ObjectCopyTo(bad, bade);
                            if (bade != null)
                            {
                                badeList.Add(bade);
                            }
                        }
                    }

                    return badeList;
                }
                catch (System.Exception ex)
                {
                    recordCount = 0;
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据账户ID和时间查询账户信息
        /// </summary>
        /// <param name="email">邮件</param>
        /// <param name="message"> 返回信息 </param>
        /// <param name="tel">电话</param>
        /// <param name="userid">用户ID</param>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        public static List<Base_t_AccountInfoEntity> SelectAccountInfoByAllInfo(string userids, string email, string tel, out string message)
        {
            message = "";
            //临时存储所有需要返回的用户ID
            List<string> userIdList = new List<string>();
            List<string> endUserIdList = new List<string>();
            if (!string.IsNullOrEmpty(userids))
            {
                //因为传入的用户id有可能是多个，所以拆分生成list给临时变量
                userIdList = userids.Split(',').ToList();
            }

            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                //根据手机的邮箱地址查询所有相关的安全账户信息
                List<Base_t_AccountScurityInfo> basiList = new List<Base_t_AccountScurityInfo>();
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(tel))
                {
                    basiList = adsdc.Base_t_AccountScurityInfo.Where(p => p.scurityEmail == email.Trim() && p.scurityTel == tel.Trim()).ToList<Base_t_AccountScurityInfo>();
                }
                else
                {
                    if (!string.IsNullOrEmpty(email))
                        basiList = adsdc.Base_t_AccountScurityInfo.Where(p => p.scurityEmail == email).ToList <Base_t_AccountScurityInfo>();
                    if (!string.IsNullOrEmpty(tel))
                        basiList = adsdc.Base_t_AccountScurityInfo.Where(p => p.scurityTel == tel.Trim()).ToList<Base_t_AccountScurityInfo>();
                }

                //如果手机和邮箱没传入参数，则查询的用户ID就等于传入的userIDs
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(tel))
                {
                    endUserIdList = userIdList;
                }
                else
                    //如果根据邮箱和手机找到了userID追加到之前的userId中
                    if (basiList != null && basiList.Count > 0)
                    {
                        List<string> tempUserIdList = new List<string>();
                        tempUserIdList = basiList.Select(p => p.accountId.ToString()).ToList();

                        //合并取出，即在userIdList中又在tempUserIdList中的userID,即查询条件的并集数据
                        foreach (string userid in tempUserIdList)
                        {
                            if (userIdList.IndexOf(userid) >= 0)
                            {
                                endUserIdList.Add(userid);
                            }
                        }
                    }

                

                List<Base_t_AccountInfoEntity> baieList = new List<Base_t_AccountInfoEntity>();
                Base_t_AccountInfoEntity baie;
                List<Base_t_AccountInfo> baiList = new List<Base_t_AccountInfo>();
                try
                {

                    var results = from C in adsdc.Base_t_AccountInfo  select C;
                    if (endUserIdList != null && endUserIdList.Count > 0)
                    {
                        foreach (string userId in endUserIdList)
                        {
                            results = results.Where(c => c.userId == userId);
                        }
                        baiList = results.OrderByDescending(c => c.createTime).ToList();
                    }
                    else
                        baiList = null;

                    if (baiList != null && baiList.Count > 0)
                    {
                        foreach (Base_t_AccountInfo bai in baiList)
                        {
                            baie = new Base_t_AccountInfoEntity();
                            PublicFunction.ObjectCopyTo(bai, baie);
                            if (baie != null)
                            {
                                baieList.Add(baie);
                            }
                        }
                    }

                    return baieList;
                }
                catch (System.Exception ex)
                {
                    message = ex.Message;
                    return null;
                }
            }
        }


        /// <summary>
        /// 根据用户ID查询账户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public static Base_t_AccountInfoEntity SelectAccountInfoByUserId(string userId)
        {
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                Base_t_AccountInfoEntity baie = new Base_t_AccountInfoEntity();
                Base_t_AccountInfo bai = new Base_t_AccountInfo();
                bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.userId == userId.Trim());
                if (bai != null)
                {
                    PublicFunction.ObjectCopyTo(bai, baie);
                }
                else
                    return null;
                return baie;
            }
        }

        /// <summary>
        ///  锁定账户信息
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="mark">操作描述说明</param>
        /// <param name="operId">操作ID</param>
        /// <param name="subjecId">操作子系统编码</param>
        /// <returns></returns>
        public static bool BlockAccountInfo(int accountId, string userCode, string userName, string operId, string mark, string subjecCode, out string message)
        {
            message = "";
            bool retFlag = false;
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                Base_t_AccountInfo bai = new Base_t_AccountInfo();
                bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == accountId);
                if (bai != null)
                {
                    try
                    {
                        bai.status = 2;
                        adsdc.SubmitChanges();
                        retFlag = true;
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        retFlag = false;
                    }
                }
                else
                {
                    message = "该账户不存在！";
                    retFlag = false;
                }

                //如果锁定成功，插入流水记录
                if (retFlag)
                {
                    Base_t_AccountDetailEntity bade = new Base_t_AccountDetailEntity();
                    bade.Type = 2;
                    bade.AccountId = accountId;
                    bade.OpTime = DateTime.Now;
                    bade.CustmerCode = userCode;
                    bade.CustmerName = userName;
                    bade.OpUser = operId;
                    bade.Resume = mark;
                    bade.SubjectCode = subjecCode;

                    //插入流水信息记录
                    InsertOperBalanceInfo(bade, out message);
                    retFlag = true;
                }

                return retFlag;
            }
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
        public static bool UnBlockAccountInfo(int accountId, string userCode, string userName, string operId, string mark, string subjecCode, out string message)
        {
            message = "";
            bool retFlag = false;
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                Base_t_AccountInfo bai = new Base_t_AccountInfo();
                bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == accountId);
                if (bai != null)
                {
                    try
                    {
                        bai.status = 1;
                        adsdc.SubmitChanges();
                        retFlag = true;
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        retFlag = false;
                    }
                }
                else
                {
                    message = "该账户不存在！";
                    retFlag = false;
                }

                //如果锁定成功，插入流水记录
                if (retFlag)
                {
                    Base_t_AccountDetailEntity bade = new Base_t_AccountDetailEntity();
                    bade.Type = 3;
                    bade.AccountId = accountId;
                    bade.OpTime = DateTime.Now;
                    bade.CustmerCode = userCode;
                    bade.CustmerName = userName;
                    bade.OpUser = operId;
                    bade.Resume = mark;
                    bade.SubjectCode = subjecCode;

                    //插入流水信息记录
                    InsertOperBalanceInfo(bade, out message);
                    retFlag = true;
                }

                return retFlag;
            }
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
        public static bool BlockAccountBalance(int accountId, string operId, string mark, string subjecCode, decimal balance, out string message)
        {
            message = "";
            bool retFlag = false;
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                DbTransaction tran = adsdc.Connection.BeginTransaction();
                Base_t_AccountInfo bai = new Base_t_AccountInfo();
                bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == accountId);
                if (bai != null)
                {
                    try
                    {
                        if (bai.balance-bai.blockBalance < balance)
                        {
                            message = "账户可用余额不足，请确定锁定金额是否超限";
                            retFlag = false;
                        }
                        else
                        {
                            bai.blockBalance = bai.blockBalance+balance;
                            adsdc.SubmitChanges();
                            retFlag = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        retFlag = false;
                    }
                }
                else
                {
                    message = "该账户不存在！";
                    retFlag = false;
                }

                //如果锁定成功，插入流水记录
                if (retFlag)
                {
                    try
                    {
                        Base_t_AccountAuditInfoEntity baaie = new Base_t_AccountAuditInfoEntity();

                        baaie.CreateTime = DateTime.Now;
                        baaie.CreateUser = operId;

                        baaie.Type = 0;
                        baaie.AccountId = accountId;
                        baaie.OpTime = DateTime.Now;
                        baaie.OpUser = operId;
                        baaie.Remark = mark;
                        baaie.SubjectCode = subjecCode;

                        //插入流水信息记录
                        InsertAuditOperBalanceInfo(baaie, out message);
                        retFlag = true;

                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        message = ex.Message;
                        retFlag = true;
                    }
                }

                return retFlag;
            }
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
        public static bool UnBlockAccountBalance(int accountId, string operId, string mark, string subjecCode, decimal balance, out string message)
        {
            message = "";
            bool retFlag = false;
            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                DbTransaction tran = adsdc.Connection.BeginTransaction();
                Base_t_AccountInfo bai = new Base_t_AccountInfo();
                bai = adsdc.Base_t_AccountInfo.FirstOrDefault(p => p.id == accountId);
                if (bai != null)
                {
                    try
                    {
                        if (bai.blockBalance < balance)
                        {
                            message = "账户可解锁余额不足，请确定解锁金额是否超限";
                            retFlag = false;
                        }
                        else
                        {
                            bai.blockBalance = bai.blockBalance - balance;
                            adsdc.SubmitChanges();
                            retFlag = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        retFlag = false;
                    }
                }
                else
                {
                    message = "该账户不存在！";
                    retFlag = false;
                }

                //如果锁定成功，插入流水记录
                if (retFlag)
                {
                    try
                    {
                        Base_t_AccountAuditInfoEntity baaie = new Base_t_AccountAuditInfoEntity();

                        baaie.CreateTime = DateTime.Now;
                        baaie.CreateUser = operId;

                        baaie.Type = 1;
                        baaie.AccountId = accountId;
                        baaie.OpTime = DateTime.Now;
                        baaie.OpUser = operId;
                        baaie.Remark = mark;
                        baaie.SubjectCode = subjecCode;

                        //插入流水信息记录
                        InsertAuditOperBalanceInfo(baaie, out message);
                        retFlag = true;

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        message = ex.Message;
                        retFlag = true;
                    }
                }

                return retFlag;
            }
        }
    }
}
