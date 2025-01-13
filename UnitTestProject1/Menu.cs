using OpenQA.Selenium;

namespace SoftwareTestingProject
{
    class Menu : CorePage
    {
        By menuBtn = By.Id("react-burger-menu-btn");
        By AboutBtn = By.Id("about_sidebar_link");
        By LogoutBtn = By.Id("logout_sidebar_link");
        By ResetBtn = By.Id("reset_sidebar_link");


        public void About()
        {
           Step = Test.CreateNode("click on AboutBtn");
            click(menuBtn);
            click(AboutBtn);
        }
        public void LogOut()
        {
            Step = Test.CreateNode("click on MenueBtn");
            click(menuBtn);
            click(LogoutBtn);
        }
        public void Reset()
        {
           Step = Test.CreateNode("click on ResetBtn");
            click(menuBtn);
            click(ResetBtn);
        }
    }
}
