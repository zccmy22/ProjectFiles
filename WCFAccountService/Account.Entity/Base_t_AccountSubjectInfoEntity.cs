using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Account.Entity
{

    [Serializable]
    [DataContract]
    public class Base_t_AccountSubjectInfoEntity
    {
        #region Field Members

        private int m_Id = 0;
        private int m_SubjectType = 0;
        private string m_SubjectName = "";
        private string m_SubjectCode = "";
        private string m_Direction = "";
        private int m_ParentId = 0;

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
        /// 系统类型
        /// </summary>
        [DataMember]
        public int SubjectType
        {
            get
            {
                return this.m_SubjectType;
            }
            set
            {
                this.m_SubjectType = value;
            }
        }
        /// <summary>
        /// 系统名称
        /// </summary>
        [DataMember]
        public string SubjectName
        {
            get
            {
                return this.m_SubjectName;
            }
            set
            {
                this.m_SubjectName = value;
            }
        }
        /// <summary>
        /// 系统编码
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
        /// 父ID
        /// </summary>
        [DataMember]
        public int ParentId
        {
            get
            {
                return this.m_ParentId;
            }
            set
            {
                this.m_ParentId = value;
            }
        }


        #endregion
    }
}
