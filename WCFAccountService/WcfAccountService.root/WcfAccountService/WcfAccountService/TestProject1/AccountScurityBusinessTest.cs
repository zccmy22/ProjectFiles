using Account.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Account.Entity;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 AccountScurityBusinessTest 的测试类，旨在
    ///包含所有 AccountScurityBusinessTest 单元测试
    ///</summary>
    [TestClass()]
    public class AccountScurityBusinessTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///SelectScurityInfo 的测试
        ///</summary>
        [TestMethod()]
        public void SelectScurityInfoTest()
        {
            int accountId = 0; // TODO: 初始化为适当的值
            Base_t_AccountScurityInfoEntity expected = null; // TODO: 初始化为适当的值
            Base_t_AccountScurityInfoEntity actual;
            actual = AccountScurityBusiness.SelectScurityInfo(accountId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///InsertAccountScurityInfo 的测试
        ///</summary>
        [TestMethod()]
        public void InsertAccountScurityInfoTest()
        {
            Base_t_AccountScurityInfoEntity basie = new Base_t_AccountScurityInfoEntity() ; // TODO: 初始化为适当的值
            basie.UseNumber = 3;
            basie.WaitUpdateScurityEmail = "test@163.com";
            basie.WaitUpdateScurityTel = "12341234123";
            basie.PayPassword = "123";
            string message = string.Empty; // TODO: 初始化为适当的值
            string messageExpected = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = AccountScurityBusiness.InsertAccountScurityInfo(basie, out message);
            Assert.AreEqual(messageExpected, message);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAccountScurityInfo 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAccountScurityInfoTest()
        {
            Base_t_AccountScurityInfoEntity basie =  new Base_t_AccountScurityInfoEntity(); // TODO: 初始化为适当的值
            basie.AccountId = 1;
            basie.WaitUpdateScurityEmail = "663763972@qq.com";
            basie.EmailValidateCode = "663763972m";
            basie.EmailExpirationTime = DateTime.Now.AddMinutes(5);
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = AccountScurityBusiness.UpdateAccountScurityInfo(basie);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
