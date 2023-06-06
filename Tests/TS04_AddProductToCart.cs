using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OnlineShoePortal.PageObjects;

namespace OnlineShoePortal
{
    [TestClass]
    public class TS04_AddProductToCart
    {


        [TestMethod]
        public void TC04_AdddProductToCart()
        {

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            PropertiesCollections.driver = new ChromeDriver(chromeOptions);
            PropertiesCollections.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

            HomePage.click_SignInPortal();

            SignInPage.enterUserName();
            SignInPage.enterPassword();
            SignInPage.clickLogin();
            ShoeTypes.clickFormalShoeCollection();
            FormalShoesTypes.Add_Product_to_Cart();
            Assert.AreEqual("Added to Cart Successfully !!!", SuccessProductToCart.SuccessMsg);

            PropertiesCollections.driver.Close();
            PropertiesCollections.driver.Quit();
        }
    }
}
