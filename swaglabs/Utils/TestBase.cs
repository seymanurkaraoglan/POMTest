using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using swaglabs.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace swaglabs.Utils;

public class TestBase
{
    protected IWebDriver driver;
    
    protected BasePage basePage;
    protected LoginPage loginPage;
    protected ProductsPage productsPage;

    protected string username = "standard_user";
    protected string password = "secret_sauce";
    
    
    [SetUp]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        //var driverPath = Environment.GetEnvironmentVariable("HOME") + "./dotnet/tools";
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        //options.BinaryLocation = "/usr/bin/google-chrome";
        driver = new ChromeDriver(options);
        //driver = new ChromeDriver();
        
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
        basePage = new BasePage();
        basePage.setDriver(driver);
        loginPage = new LoginPage();
        
    }

    [TearDown]
    public void TearDown()
    {
        Thread.Sleep(3000);
        driver.Quit();
        driver.Dispose();
    }
    
}