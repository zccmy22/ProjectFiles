using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Account.Entity
{
    [Serializable]
    [DataContract]
    public class Base_t_AccountDetailEntity
    {    
        #region Field Members

        private int m_Id = 0;         
        private int m_AccountId = 0;         
        private int m_Type = 0;         
        private string m_Orderid = "";         
        private string m_Resume = "";         
        private string m_SubjectCode = "";         
        private int m_CustmerType = 0;         
        private string m_CustmerCode = "";         
        private string m_CustmerName = "";         
        private decimal m_UseBalance = 0;         
        private decimal m_EndBalance = 0;         
        private DateTime m_OpTime = System.DateTime.Now;         
        private string m_OpUser = "";         

        #endregion

        #region Property Members
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
        /// 操作类型
        /// </summary>
        [DataMember]
        public int Type
        {
            get
            {
                return this.m_Type;
            }
            set
            {
                this.m_Type = value;
            }
        }
        /// <summary>
        /// 订单、退单ID
        /// </summary>
        [DataMember]
        public string Orderid
        {
            get
            {
                return this.m_Orderid;
            }
            set
            {
                this.m_Orderid = value;
            }
        }
        /// <summary>
        /// 简要说明
        /// </summary>
        [DataMember]
        public string Resume
        {
            get
            {
                return this.m_Resume;
            }
            set
            {
                this.m_Resume = value;
            }
        }
        /// <summary>
        /// 子系统编码
        /// </summary>
        [DataMember]
        public string SubjectCode
        {
            get
            {
                return this.m_SubjectCode;
            }
            set
            {
                this.m_SubjectCode = value;
            }
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        [DataMember]
        public int CustmerType
        {
            get
            {
                return this.m_CustmerType;
            }
            set
            {
                this.m_CustmerType = value;
            }
        }
        /// <summary>
        /// 用户编码
        /// </summary>
        [DataMember]
        public string CustmerCode
        {
            get
            {
                return this.m_CustmerCode;
            }
            set
            {
                this.m_CustmerCode = value;
            }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string CustmerName
        {
            get
            {
                return this.m_CustmerName;
            }
            set
            {
                this.m_CustmerName = value;
            }
        }
        /// <summary>
        /// 使用余额
        /// </summary>
        [DataMember]
        public decimal UseBalance
        {
            get
            {
                return this.m_UseBalance;
            }
            set
            {
                this.m_UseBalance = value;
            }
        }
        /// <summary>
        ///  剩余余额
        /// </summary>
        [DataMember]
        public decimal EndBalance
        {
            get
            {
                return this.m_EndBalance;
            }
            set
            {
                this.m_EndBalance = value;
            }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember]
        public DateTime OpTime
        {
            get
            {
                return this.m_OpTime;
            }
            set
            {
                this.m_OpTime = value;
            }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember]
        public string OpUser
        {
            get
            {
                return this.m_OpUser;
            }
            set
            {
                this.m_OpUser = value;
            }
        }


        #endregion

    }
}
