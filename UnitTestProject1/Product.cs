using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTestingProject
{
    class ProductPage : CorePage
    {
        By Pr1 = By.Id("item_4_title_link");
        By AddtoCartBtn = By.Id("add-to-cart-sauce-labs-backpack");
        By RemoveFromCart = By.Id("remove-sauce-labs-backpack");
        By BackToProductPage = By.Id("back-to-products");
        //By Products = By.Id("item_4_title_link");
        By Add = By.Id("add-to-cart-sauce-labs-backpack");




        public void Addtocartfromfrontpage()
        {
            Step = Test.CreateNode("Addtocartfromfrontpage");
            click(Add);
        }




        public void Product_AddToCart()
        {
            Step = Test.CreateNode("Product_AddToCart");
            click(Pr1);
            click(AddtoCartBtn);
            // driver.FindElement(BackToProductPage).Click();
        }
        public void Product_Delete()
        {
            Step = Test.CreateNode("Product_Delete");
            click(Pr1);
            click(AddtoCartBtn);
            click(RemoveFromCart);
            click(BackToProductPage);

        }
    }
}
