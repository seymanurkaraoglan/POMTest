using NUnit.Framework;
using OpenQA.Selenium;
using swaglabs.Pages;
using swaglabs.Utils;

namespace swaglabs.Tests;
[TestFixture]
public class LoginTests : TestBase
{
    private LoginPage loginPage = new  LoginPage();
    
    [Test,Category("Step1")]
    public void LoginSuccesTest()
    {
        loginPage.login("standard_user","secret_sauce");
        Assert.That(driver.Url.Contains("inventory"));
        Console.WriteLine("ürünler sayfası görüldü");
    } 
    /*[Test]
    public void failedLoginTest()
    {
        loginPage.login("standard_user", "11111");
        string actual = loginPage.getErrorMessage();
        string expected = "Epic sadface";
        Assert.That(actual, Does.Contain(expected));
    }*/
    
    [Test,Category("Step5")]
    public void LogoutTest()
    {
        //loginPage.login("standard_user","secret_sauce");
        loginPage.logout();
        Assert.That(loginPage.isLoginFormPresent(), Is.True);
    }
}