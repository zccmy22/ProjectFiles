using Account.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Account.Entity;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 AccountBusinessTest 的测试类，旨在
    ///包含所有 AccountBusinessTest 单元测试
    ///</summary>
    [TestClass()]
    public class AccountBusinessTest
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
        ///InsertAccountInfo 的测试
        ///</summary>
        [TestMethod()]
        public void InsertAccountInfoTest()
        {
            Base_t_AccountInfoEntity baie = new Base_t_AccountInfoEntity(); // TODO: 初始化为适当的值
            baie.AccCode = "12345";
            baie.Balance = 300;
            baie.UserId = "userid";
            baie.BlockBalance = 200;
            baie.CreateTime = DateTime.Now;
            baie.Status = 1;
            baie.UserType = 2;

            string message = string.Empty; // TODO: 初始化为适当的值
            string account = string.Empty; // TODO: 初始化为适当的值
            string messageExpected = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = AccountBusiness.InsertAccountInfo(baie,out account, out message);
            Assert.AreEqual(messageExpected, message);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///AddBalance 的测试
        ///</summary>
        [TestMethod()]
        public void AddBalanceTest()
        {
            Decimal balance = new Decimal(99.00); // TODO: 初始化为适当的值
            int accountId = 2; // TODO: 初始化为适当的值
            string message = string.Empty; // TODO: 初始化为适当的值
            string messageExpected = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = AccountBusiness.AddBalance(balance, accountId, out message);
            Assert.AreEqual(messageExpected, message);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SelectAccoutnDetailInfoByTime 的测试
        ///</summary>
        [TestMethod()]
        public void SelectAccoutnDetailInfoByTimeTest()
        {
            int accountId = 1; // TODO: 初始化为适当的值
            string starTime = DateTime.Now.AddDays(-5).ToString(); // TODO: 初始化为适当的值
            string endTime = DateTime.Now.AddDays(1).ToString() ; // TODO: 初始化为适当的值
            int pageSize = 10; // TODO: 初始化为适当的值
            int pageNumber = 1; // TODO: 初始化为适当的值
            int recordCount = 0; // TODO: 初始化为适当的值
            int recordCountExpected = 0; // TODO: 初始化为适当的值
            List<Base_t_AccountDetailEntity> expected = null; // TODO: 初始化为适当的值
            List<Base_t_AccountDetailEntity> actual;
            //actual = AccountBusiness.SelectAccoutnDetailInfoByTime(accountId, starTime, endTime, pageSize, pageNumber, out recordCount);
            Assert.AreEqual(recordCountExpected, recordCount);
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
