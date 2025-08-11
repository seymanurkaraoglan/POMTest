using OpenQA.Selenium;

namespace swaglabs.Pages;

public class BasePage
{
    public static IWebDriver driver;

    public void setDriver(IWebDriver driver) {
        BasePage.driver = driver;
    }

    protected IWebElement find(By locator)
    {
        return driver.FindElement(locator);
    }

    protected IReadOnlyCollection<IWebElement> FindAll(By locator)
    {
        return driver.FindElements(locator);
    }

    protected ProductsPage Click(By locator)
    {
        find(locator).Click();
        return new ProductsPage();
    }

    protected void Type(By locator, string text)
    {
        var element =  find(locator);
        element.Clear();
        element.SendKeys(text);
    }

    protected string GetText(By locator)
    {
        return find(locator).Text;
    }

    protected bool isDisplayed(By locator)
    {
        try
        {
            return find(locator).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public void ScrollToElement(By locator)
    {
        IWebElement element = driver.FindElement(locator);
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
    
    public void clickJS(By locator)
    {
        IWebElement element = driver.FindElement(locator);
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].click();", element);
    }
}