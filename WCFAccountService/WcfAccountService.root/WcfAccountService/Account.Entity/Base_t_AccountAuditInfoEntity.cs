using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Account.Entity
{
    [Serializable]
    [DataContract]
    public class Base_t_AccountAuditInfoEntity
    {    
        #region Field Members

        private int m_Id = 0;         
        private int m_AccountId = 0;         
        private int m_Type = 0;         
        private string m_Direction = "";
        private string m_SubjectCode = "";
        private int m_CustmerType = 0;
        private string m_CustmerCode = "";
        private string m_CustmerName = "";          
        private string m_RefId = "";         
        private decimal m_OpBalance = 0;         
        private bool m_Status = false;         
        private DateTime? m_CreateTime = null;         
        private DateTime? m_OpTime = null;         
        private string m_OpUser = "";
        private string m_Remark = "";
        private string m_createUser;       

        #endregion

        #region Property Members
        /// <summary>
        /// 表Id   
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
        /// 描述
        /// </summary>
        [DataMember]
        public string Direction
        {
            get
            {
                return this.m_Direction;
            }
            set
            {
                this.m_Direction = value;
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
        /// 相关系统操作ID（如退单号）
        /// </summary>
        [DataMember]
        public string RefId
        {
            get
            {
                return this.m_RefId;
            }
            set
            {
                this.m_RefId = value;
            }
        }
        /// <summary>
        /// 待审核余额
        /// </summary>
        [DataMember]
        public decimal OpBalance
        {
            get
            {
                return this.m_OpBalance;
            }
            set
            {
                this.m_OpBalance = value;
            }
        }
        /// <summary>
        /// 审枋状态
        /// </summary>
        [DataMember]
        public bool Status
        {
            get
            {
                return this.m_Status;
            }
            set
            {
                this.m_Status = value;
            }
        }
        /// <summary>
        /// 创建 时间
        /// </summary>
        [DataMember]
        public DateTime? CreateTime
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
        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember]
        public DateTime? OpTime
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
        /// 审核人
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
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark
        {
            get
            {
                return this.m_Remark;
            }
            set
            {
                this.m_Remark = value;
            }
        }

        /// <summary>
        /// 创建者
        /// </summary>
        [DataMember]
        public string CreateUser
        {
            get
            {
                return this.m_createUser;
            }
            set
            {
                this.m_createUser = value;
            }
        }

        #endregion

    }
}
