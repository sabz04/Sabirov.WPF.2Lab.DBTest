using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sabirov.WPF._2Lab.DBTest;
using Sabirov.WPF._2Lab.DBTest.Pages;
using System;
using System.Data;

namespace DBTestLibrary
{
    [TestClass]
    public class UnitTest1
    {
        static string log = "1";
        static string pass = "";
        static User user = new User();
        [TestMethod]
        public void LoginTest()
        {
            Assert.IsTrue(Login.IsUserExists(log, pass));
        }
        [TestMethod]
        public void RegTest()
        {
            Assert.IsTrue(Register.IsUserExists(log, pass));
        }

        [TestMethod]
        public void StatusAdminTest()
        {
            Assert.IsTrue(InfoPanel.IsAdmin("zupatik"));
        }

        [TestMethod]
        public void StatusUserTest()
        {
            Assert.IsTrue(InfoPanel.IsUser("zupatik"));
        }
        [TestMethod]
        public void IsAddTest()
        {
            Assert.IsTrue(AdminPanel.IsAdded());
        }
        [TestMethod]
        public void IsShowTest()
        {
            Assert.IsTrue(BooksPanel.BooksLoad());
        }

    }
}
