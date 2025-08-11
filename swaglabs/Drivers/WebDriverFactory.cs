using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace swaglabs.Drivers;

public class WebDriverFactory
{
    public static IWebDriver driver;

    public IWebDriver GetDriver()
    {
        if (driver == null)
        {
            //daha önce driver oluşturulmamışsa oluştur
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }
        return driver;
    }

    public static void QuitDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }
}