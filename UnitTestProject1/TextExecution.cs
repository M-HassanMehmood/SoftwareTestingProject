using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace SoftwareTestingProject
{
    [TestClass]
    public class TestExecution : CorePage
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
             string ResultFile = @"C:\ExtentReports\TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
             CreateReport(ResultFile);
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();
        }
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }
        [TestInitialize()]
        public void TestInit()
        {
            SeleniumInit(ConfigurationManager.AppSettings["browser"].ToString());
           // SeleniumInit();
            Test = extentReports.CreateTest(TestContext.TestName);

        }
        [TestCleanup]
        public void TestCleanup()
        {
            CloseSelenium();
        }
        // #endregion
        //  IWebDriver driver = new ChromeDriver();
        LoginPage loginPage = new LoginPage();
        ProductPage productPage = new ProductPage();
        CartAndCheckOutPage cartPage = new CartAndCheckOutPage();
        Menu MenuPgae = new Menu();
        CorePage corePage = new CorePage(); 
        //ProductSort Sort = new ProductSort();

        [TestMethod, TestCategory("Login"), TestCategory("Positive")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "loginWithAllPossibleDetails_TC001", DataAccessMethod.Sequential)]
        public void loginWithAllPossibleDetails_TC001()
        {

            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string Locator = TestContext.DataRow["Locator"].ToString();
            string Msg = TestContext.DataRow["Msg"].ToString();

            loginPage.login(url, username, password);
            string message = driver.FindElement(By.ClassName(Locator)).Text;
            Assert.AreEqual(Msg, message);

        }
        [TestMethod, TestCategory("AddToCartOrDelete"), TestCategory("Positive")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "ProductPageExecutionTest001", DataAccessMethod.Sequential)]

        public void ProductPageExecutionTest001()
        {

            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string Locator = TestContext.DataRow["Locator"].ToString();
            string Msg = TestContext.DataRow["Msg"].ToString();

            loginPage.login(url, username, password);
            string msg = driver.FindElement(By.ClassName(Locator)).Text;
            Assert.AreEqual(Msg, msg);
            productPage.Product_AddToCart();
            cartPage.Continue_Shopping();
            Thread.Sleep(2000);
            productPage.Product_Delete();


        }

        [TestMethod, TestCategory("CheckOutAfterAddTocartProduct"), TestCategory("Positive")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "CartPageExecutionTest002", DataAccessMethod.Sequential)]

        public void CartPageExecutionTest002()
        {

            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string postalCode = TestContext.DataRow["postalCode"].ToString();
            string Locator = TestContext.DataRow["Locator"].ToString();
            string Msg = TestContext.DataRow["Msg"].ToString();
            string Locator1 = TestContext.DataRow["Locator1"].ToString();
            string Msg1 = TestContext.DataRow["Msg1"].ToString();

            loginPage.login(url, username, password);
            productPage.Product_AddToCart();
            cartPage.CheckOut(firstName, lastName, postalCode);
            cartPage.Continue();
            cartPage.CompleteOrder();
            string Complete = driver.FindElement(By.ClassName(Locator)).Text;
            Assert.AreEqual(Msg, Complete);
            cartPage.GoBackHome();
            string message = driver.FindElement(By.ClassName(Locator1)).Text;
            Assert.AreEqual(Msg1, message);
        }

        [TestMethod, TestCategory("CheckOutAfterAddTocartProductWithAllAttributes")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "CartPageExecutionTest003", DataAccessMethod.Sequential)]
        public void CartPageExecutionTest003()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string postalCode = TestContext.DataRow["postalCode"].ToString();
            string Locator = TestContext.DataRow["Locator"].ToString();
            string Msg = TestContext.DataRow["Msg"].ToString();
            loginPage.login(url, username, password);
            productPage.Product_AddToCart();
            cartPage.CheckOut(firstName, lastName, postalCode);
            cartPage.Continue();
            string ErrorMsg = driver.FindElement(By.ClassName(Locator)).Text;
            Assert.AreEqual(Msg, ErrorMsg);
        }
        [TestMethod, TestCategory("CancleBtn"), TestCategory("Negative")]
        public void CartPageExecutionTest004()
        {
            loginPage.login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            productPage.Product_AddToCart();
            cartPage.CheckOut("Hassan", "Mehmood", "10001");
            cartPage.Continue();
            cartPage.CancleBtn();
        }
        [TestMethod, TestCategory("CancleBtn"), TestCategory("Negative")]
        public void CartPageExecutionTest005()
        {
            loginPage.login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            productPage.Product_AddToCart();
            cartPage.CheckOut("", "", "");
            cartPage.CancleBtn();
        }
        [TestMethod, TestCategory("AboutBtn"), TestCategory("Positive")]
        public void MenuExecutionTest001()
        {
            loginPage.login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            MenuPgae.About();
        }
        [TestMethod, TestCategory("LogoutBtn"), TestCategory("Positive")]
        public void MenuExecutionTest002()
        {
            loginPage.login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            MenuPgae.LogOut();
        }
        [TestMethod, TestCategory("ResetBtn"), TestCategory("Positive")]
        public void MenuExecutionTest003()
        {
            loginPage.login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            productPage.Product_AddToCart();
            MenuPgae.Reset();
        }

/*
        [TestMethod]

        public void ProductSortExecutionTest001()
        {
            loginPage.login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            Sort.Product_Sort();

        }*/

    }
}
