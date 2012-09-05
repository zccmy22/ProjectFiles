using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Account.Entity
{
    [Serializable]
    [DataContract]
    public class Base_t_AccountInfoEntity
    {    
        #region Field Members

        private int m_Id = 0;         
        private int m_UserType = 0;         
        private string m_UserId = "";         
        private decimal m_Balance = 0;         
        private int m_Status = 0;
        private string m_AccCode = "";         
        private decimal m_BlockBalance = 0;         
        private DateTime m_CreateTime = System.DateTime.Now;         

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
        /// 用户类型
        /// </summary>
        [DataMember]
        public int UserType
        {
            get
            {
                return this.m_UserType;
            }
            set
            {
                this.m_UserType = value;
            }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public string UserId
        {
            get
            {
                return this.m_UserId;
            }
            set
            {
                this.m_UserId = value;
            }
        }
        /// <summary>
        /// 余额
        /// </summary>
        [DataMember]
        public decimal Balance
        {
            get
            {
                return this.m_Balance;
            }
            set
            {
                this.m_Balance = value;
            }
        }
        /// <summary>
        /// 账户状态
        /// </summary>
        [DataMember]
        public int Status
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
        /// 账户编码
        /// </summary>
        [DataMember]
        public string AccCode
        {
            get
            {
                return this.m_AccCode;
            }
            set
            {
                this.m_AccCode = value;
            }
        }
        /// <summary>
        /// 锁定余额
        /// </summary>
        [DataMember]
        public decimal BlockBalance
        {
            get
            {
                return this.m_BlockBalance;
            }
            set
            {
                this.m_BlockBalance = value;
            }
        }
        /// <summary>
        /// 创建时间
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
