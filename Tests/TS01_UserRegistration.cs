﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OnlineShoePortal.PageObjects;

namespace OnlineShoePortal
{
    [TestClass]
    public class TS01_User_Registration
    {


        [TestMethod]
        public void TC01_UserReg_ErrValidation()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            PropertiesCollections.driver = new ChromeDriver( chromeOptions);
            PropertiesCollections.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

            HomePage.click_SignInPortal();

            Assert.AreEqual(1, SignInPage.txtuserlength);
            Assert.AreEqual(1, SignInPage.txtpwdlength);
            Assert.AreEqual(1, SignInPage.btnLogin);
            Assert.AreEqual(1, SignInPage.btnRegistration);

            SignInPage.clickNewRegistration();

            RegistrationPage.select_Salutation();
            RegistrationPage.click_Submit();

            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_FirstName();
            RegistrationPage.click_Submit();

            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_LastName();
            RegistrationPage.click_Submit();

            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_InvalidEmail();
            RegistrationPage.click_Submit();

            Assert.AreEqual("Enter a valid email", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_ValidEmail();
            RegistrationPage.click_Submit();

            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_UsrName();
            RegistrationPage.click_Submit();
            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_Password();
            RegistrationPage.click_Submit();

            PropertiesCollections.driver.Close();
            PropertiesCollections.driver.Quit();

        }
    }
}
