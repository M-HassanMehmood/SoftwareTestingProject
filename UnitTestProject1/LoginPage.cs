using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;


namespace SoftwareTestingProject
{
    class LoginPage : CorePage
    {

        By usernameTxt = By.Id("user-name");
        By passwordTxt = By.Id("password");
        By loginBtn = By.Id("login-button");

        public void login(string url, string username, string password)
        {
            Step = Test.CreateNode("LoginPage");

            OpenUrl(url);

            write(usernameTxt, username);

            write(passwordTxt, password);

            click(loginBtn);

        }


    }
}
