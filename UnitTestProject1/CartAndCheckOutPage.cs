using OpenQA.Selenium;


namespace SoftwareTestingProject
{
    class CartAndCheckOutPage : CorePage
    {
        By cart = By.ClassName("shopping_cart_link");
        By ContinueShopping = By.Id("continue-shopping");
        By ContinueCheckOut = By.Id("checkout");
        By FirstName = By.Id("first-name");
        By LastName = By.Id("last-name");
        By Zip_PostalCode = By.Id("postal-code");
        By ContinueBtn = By.Id("continue");
        By Finish = By.Id("finish");
        By BackHome = By.Id("back-to-products");
        By CancelBtn = By.Id("cancel");

        public void Continue_Shopping()
        {
            Step = Test.CreateNode("click on ContinueShopping");
            click(cart);
            click(ContinueShopping);
        }
        public void CheckOut(string firstName, string lastName, string postalCode)
        {
            //Step = Test.CreateNode("CheckOut");
            click(cart);
            click(ContinueCheckOut);
            write(FirstName, firstName);
            write(LastName, lastName);
            write(Zip_PostalCode, postalCode);
        }
        public void Continue()
        {
            Step = Test.CreateNode("click on ContinueBtn");
            click(ContinueBtn);
        }
        public void CompleteOrder()
        {
           Step = Test.CreateNode("click on FinishBtn");
            click(Finish);
        }
        public void GoBackHome()
        {
            Step = Test.CreateNode("click on BackBtn");
            click(BackHome);
        }
        public void CancleBtn()
        {
            Step = Test.CreateNode("click on CancelBtn");
            click(CancelBtn);
        }

    }
}
