using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Account.Entity;
using Account.Data;
using Account.Common;

namespace Account.Business
{
    public class AccountScurityBusiness
    {
        
        /// <summary>
        /// 查询安全信息
        /// </summary>
        /// <param name="sId"></param>
        /// <returns></returns>
        public static Base_t_AccountScurityInfoEntity SelectScurityInfo(int accountId)
        {
            //定义临时存储实体变量，便于一会实体转换和返回
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();
            Base_t_AccountScurityInfoEntity basie = new Base_t_AccountScurityInfoEntity();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId);
            if (basi != null)
            {
                PublicFunction.ObjectCopyTo(basi, basie);
                return basie;
            }
            else
                return null;
        }
        /// <summary>
        /// 验证手机信息
        /// </summary>
        /// <param name="telNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool ValidateTel(string telNo, string validateCode, int accountId, out string message)
        {
            message = "";
            bool retFlag = true;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId);

            if (basi == null)
            {
                message = "此用户不存在，验证失败";
                retFlag = false;
            }
            else
            {
                if (DateTime.Now > basi.telExpirationTime)
                {
                    message = "效验码已过期";
                    retFlag = false;
                }
                else
                {
                    if (basi.telValidateCode != validateCode.Trim())
                    {
                        message = "效验码不正确";
                        retFlag = false;
                    }
                    else
                    {
                        retFlag = true;
                    }
                }
            }
            //如果验证通过，自动更新安全手机为此手机
            if (retFlag)
            {
                basi.scurityTel = basi.waitUpdateScurityTel;
                basi.isUseTel = true;
                adsdc.SubmitChanges();
                message = "已验证通过，并更新了安全手机";
            }

            return retFlag;
        }
        /// <summary>
        /// 验证邮箱信息
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string email,string validateCode, int accountId, out string message)
        {
            message = "";
            bool retFlag = true;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId);

            if (basi == null)
            {
                message = "此用户不存在，验证失败";
                retFlag = false;
            }
            else
            {
                if (basi.waitUpdateScurityEmail != email)
                {
                    message = "邮箱地址与安全邮箱不相符";
                    retFlag = false;
                }
                else
                {
                    if (DateTime.Now > basi.emailExpirationTime)
                    {
                        message = "效验码已过期";
                        retFlag = false;
                    }
                    else
                    {
                        if (basi.emailValidateCode != validateCode.Trim())
                        {
                            message = "效验码不正确";
                            retFlag = false;
                        }
                        else
                        {
                            retFlag = true;
                        }
                    }
                }
            }

            //如果验证通过，自动更新安全邮箱为此邮箱
            if (retFlag)
            {
                basi.scurityEmail = basi.waitUpdateScurityEmail;
                basi.isUseEmail = true;
                adsdc.SubmitChanges();
                message = "已验证通过，并更新了安全邮箱";
            }

            return retFlag;
        }
        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="accountId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool UpdatePayPassword(string oldPassword, string newPassword, string scurityKey, int accountId, out string message)
        {
            message = "";
            bool retFlag = true;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId);

            if (basi == null)
            {
                message = "此用户不存在，修改支付密码失败";
                retFlag = false;
            }
            else
            {
                if (oldPassword != basi.payPassword)
                {
                    message = "原始密码不正确";
                    retFlag = false;
                }
                else
                {
                    try
                    {
                        basi.payPassword = newPassword;
                        basi.pwdKey = scurityKey;
                        basi.isChangePwd = true;
                        adsdc.SubmitChanges();
                        retFlag = true;
                        message = "修改支付密码成功";

                    }
                    catch(Exception ex)
                    {
                        message = ex.Message;
                        retFlag = false;
                    }
                }
            }
            return retFlag;
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
        /// <param name="userName">发送邮件的用户名</param>
        /// <param name="password">发送邮件的密码</param>
        /// <returns>是否成功</returns>
        public static bool SendEmail(string from, string to, string subject, bool isBodyHtml, string body, string smtpHost, string userName, string password, out string message)
        {
            return PublicFunction.Send(from, to, subject, isBodyHtml, body, smtpHost, userName, password, out message);
        }

        /// <summary>
        /// 更新账户安全信息
        /// </summary>
        /// <param name="baie">账户安全信息实体</param>
        /// <returns></returns>
        public static bool UpdateAccountScurityInfo(Base_t_AccountScurityInfoEntity basie)
        {
            bool retFlag = false;
            
            if (basie == null)
                return retFlag;

            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();
            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == basie.AccountId);

            try
            {
                if (basi != null && basie != null)
                {
                    if( basie.AccountId > 0)
                        basi.accountId = basie.AccountId;
                    if (basie.EmailExpirationTime != null)
                        basi.emailExpirationTime = basie.EmailExpirationTime;
                    if (basie.TelExpirationTime != null)
                        basi.telExpirationTime = basie.TelExpirationTime;
                    if (!string.IsNullOrEmpty(basie.EmailValidateCode))
                        basi.emailValidateCode = basie.EmailValidateCode;
                    if (!string.IsNullOrEmpty(basie.WaitUpdateScurityEmail))
                        basi.waitUpdateScurityEmail = basie.WaitUpdateScurityEmail;
                    if (!string.IsNullOrEmpty(basie.WaitUpdateScurityTel))
                        basi.waitUpdateScurityTel = basie.WaitUpdateScurityTel;
                    if (!string.IsNullOrEmpty(basie.TelValidateCode))
                        basi.telValidateCode = basie.TelValidateCode;
                    if ( basie.UseNumber>0)
                        basi.useNumber = basi.useNumber + basie.UseNumber;
                    
                    adsdc.SubmitChanges();
                    retFlag = true;
                }
            }
            catch
            {
                retFlag = false;
            }
            return retFlag;

        }

        /// <summary>
        /// 更新账户邮箱安全信息
        /// </summary>
        /// <param name="baie">账户邮箱安全信息实体</param>
        /// <returns></returns>
        public static bool UpdateAccountScurityEmailInfo(string email, int accountId, out string message)
        {
            message = "";
            bool retFlag = false;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();
            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId);

            try
            {
                if (basi != null )
                {
                    basi.waitUpdateScurityEmail = email;
                    adsdc.SubmitChanges();
                    retFlag = true;
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
                retFlag = false;
            }
            return retFlag;

        }

        /// <summary>
        /// 更新账户手机安全信息
        /// </summary>
        /// <param name="baie">账户邮箱安全信息实体</param>
        /// <returns></returns>
        public static bool UpdateAccountScurityTelInfo(string tel, int accountId, out string message)
        {
            message = "";
            bool retFlag = false;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();
            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId);

            try
            {
                if (basi != null)
                {
                    basi.waitUpdateScurityTel = tel;
                    adsdc.SubmitChanges();
                    retFlag = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                retFlag = false;
            }
            return retFlag;

        }

        /// <summary>
        /// 邮箱是否唯一
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <returns></returns>
        public static bool IsOnlyOneEmail(string email)
        {
            bool retFlag = true;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.scurityEmail == email);

            if (basi != null)
                retFlag = false;
            else
                retFlag = true;

            return retFlag;
        }


        /// <summary>
        /// 新增账户安全信息
        /// </summary>
        /// <param name="basie">安全信息实体</param>
        /// <returns></returns>
        public static bool InsertAccountScurityInfo(Base_t_AccountScurityInfoEntity basie, out string message)
        {
            message = "";
            bool retFlag = false;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();
            if (basie != null)
            {
                PublicFunction.ObjectCopyTo(basie, basi);

                AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
                try
                {
                    if (basi != null && basie != null)
                    {
                        adsdc.Base_t_AccountScurityInfo.InsertOnSubmit(basi);
                        adsdc.SubmitChanges();
                        retFlag = true;
                    }
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                    retFlag = false;
                }
            }
            else
            {
                retFlag = false;
            }
            return retFlag;
        }


        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="Password">密码</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        public static bool ValidatePayPassword(string password, int accountId, out string message)
        {
            message = "";
            bool retFlag = true;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();

            using (AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext())
            {
                basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId && p.payPassword == password);

                if (basi == null || basi.id <= 0)
                {
                    message = "验证支付密码失败";
                    retFlag = false;
                }
                else
                {
                    message = "支付密码通过";
                    retFlag = true;
                }
                return retFlag;
            }
        }

        /// <summary>
        /// 重置支付密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <param name="accountId">账户ID</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        public static bool SetPayPassword(string newPassword, string scurityKey, int accountId, out string message)
        {
            message = "";
            bool retFlag = true;
            Base_t_AccountScurityInfo basi = new Base_t_AccountScurityInfo();

            AccountDataSourceDataContext adsdc = new AccountDataSourceDataContext();
            basi = adsdc.Base_t_AccountScurityInfo.FirstOrDefault(p => p.accountId == accountId);

            if (basi == null)
            {
                message = "此用户不存在，修改支付密码失败";
                retFlag = false;
            }
            else
            {
                try
                {
                    basi.payPassword = newPassword;
                    basi.pwdKey = scurityKey;
                    basi.isChangePwd = true;
                    adsdc.SubmitChanges();
                    retFlag = true;
                    message = "修改支付密码成功";
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    retFlag = false;
                }

            }
            return retFlag;
        }
    }
}
