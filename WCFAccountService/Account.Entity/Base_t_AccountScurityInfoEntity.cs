using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Account.Entity
{
    [Serializable]
    [DataContract]
    public class Base_t_AccountScurityInfoEntity
    {
        #region Field Members

        private int m_Id = 0;
        private int m_AccountId = 0;
        private string m_PayPassword = "";
        private int m_UseNumber = 0;
        private string m_ScurityEmail = "";
        private string m_ScurityTel = "";
        private bool m_IsUseEmail = false;
        private bool m_IsUseTel = false;
        private bool m_IsChangePwd = false;
        private DateTime m_CreateTime = System.DateTime.Now;
        private DateTime? m_EmailExpirationTime = null;
        private DateTime? m_TelExpirationTime= null;
        private string m_EmailValidateCode = "";
        private string m_TelValidateCode = "";
        private string m_WaitUpdateScurityEmail = "";
        private string m_WaitUpdateScurityTel = "";
        private string m_PwdKey = "";


        #endregion

        #region Property Members
        /// <summary>
        /// 密码Key
        /// </summary>
        [DataMember]
        public string PwdKey
        {
            get { return m_PwdKey; }
            set { m_PwdKey = value; }
        }
        /// <summary>
        /// 等待修改的安全邮箱地址
        /// </summary>
        [DataMember]
        public string WaitUpdateScurityEmail
        {
            get { return m_WaitUpdateScurityEmail; }
            set { m_WaitUpdateScurityEmail = value; }
        }
        /// <summary>
        /// 等待修改的安全手机地址
        /// </summary>
        [DataMember]
        public string WaitUpdateScurityTel
        {
            get { return m_WaitUpdateScurityTel; }
            set { m_WaitUpdateScurityTel = value; }
        }
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        [DataMember]
        public string EmailValidateCode
        {
            get { return m_EmailValidateCode; }
            set { m_EmailValidateCode = value; }
        }
        /// <summary>
        /// 手机验证码
        /// </summary>
        [DataMember]
        public string TelValidateCode
        {
            get { return m_TelValidateCode; }
            set { m_TelValidateCode = value; }
        }



        /// <summary>
        /// 邮箱验证过期时间
        /// </summary>
        [DataMember]
        public DateTime? EmailExpirationTime
        {
            get { return m_EmailExpirationTime; }
            set { m_EmailExpirationTime = value; }
        }
        /// <summary>
        /// 手机验证过期时间
        /// </summary>
        [DataMember]
        public DateTime? TelExpirationTime
        {
            get { return m_TelExpirationTime; }
            set { m_TelExpirationTime = value; }
        }

        /// <summary>
        /// 表ID    
        /// </summary>
        [DataMember]
        public int Id
        {
            get
            {
                return this.m_Id;
            }
            set
            {
                this.m_Id = value;
            }
        }
        /// <summary>
        /// 账户ID
        /// </summary>
        [DataMember]
        public int AccountId
        {
            get
            {
                return this.m_AccountId;
            }
            set
            {
                this.m_AccountId = value;
            }
        }
        /// <summary>
        /// 支付密码
        /// </summary>
        [DataMember]
        public string PayPassword
        {
            get
            {
                return this.m_PayPassword;
            }
            set
            {
                this.m_PayPassword = value;
            }
        }
        /// <summary>
        /// 使用次数
        /// </summary>
        [DataMember]
        public int UseNumber
        {
            get
            {
                return this.m_UseNumber;
            }
            set
            {
                this.m_UseNumber = value;
            }
        }
        /// <summary>
        /// 安全邮箱
        /// </summary>
        [DataMember]
        public string ScurityEmail
        {
            get
            {
                return this.m_ScurityEmail;
            }
            set
            {
                this.m_ScurityEmail = value;
            }
        }
        /// <summary>
        /// 安全电话
        /// </summary>
        [DataMember]
        public string ScurityTel
        {
            get
            {
                return this.m_ScurityTel;
            }
            set
            {
                this.m_ScurityTel = value;
            }
        }
        /// <summary>
        /// 是否已验证使用邮箱
        /// </summary>
        [DataMember]
        public bool IsUseEmail
        {
            get
            {
                return this.m_IsUseEmail;
            }
            set
            {
                this.m_IsUseEmail = value;
            }
        }
        /// <summary>
        /// 是否已验证使用手机
        /// </summary>
        [DataMember]
        public bool IsUseTel
        {
            get
            {
                return this.m_IsUseTel;
            }
            set
            {
                this.m_IsUseTel = value;
            }
        }
        /// <summary>
        /// 是否变更过密码
        /// </summary>
        [DataMember]
        public bool IsChangePwd
        {
            get
            {
                return this.m_IsChangePwd;
            }
            set
            {
                this.m_IsChangePwd = value;
            }
        }
        /// <summary>
        /// 创建 时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime
        {
            get
            {
                return this.m_CreateTime;
            }
            set
            {
                this.m_CreateTime = value;
            }
        }


        #endregion

    }
}
