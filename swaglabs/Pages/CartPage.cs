using OpenQA.Selenium;

namespace swaglabs.Pages;

public class CartPage : BasePage
{
   // private By cartButton = By.ClassName("shopping_cart_badge");
    private ProductsPage productsPage;
    public By cartButton = By.ClassName("shopping_cart_badge");
    private By checkoutButton = By.ClassName("cart_footer");
    private By firstname = By.Id("first-name");
    private By lastname = By.Id("last-name");
    private By postalcode = By.Id("postal-code");
    private By finishButton = By.XPath("//a[@class='btn_action cart_button']");
    private By finishHeader = By.XPath("//h2[@class='complete-header']");
    public void deleteToCart(params string[] productNames)
    {
        foreach (var productName in productNames)
        {
            /*var locator = By.XPath(
                $"//div[@class='inventory_item_name' and text()='{productName}']" +
                "/ancestor::div[contains(@class,'item_pricebar')]//button"
            );*/
            var locator = By.XPath(
                $"//div[@class='inventory_item_name' and text()='{productName}']" +
                "/ancestor::div[contains(@class,'cart_item')]//button"
            );
            ScrollToElement(locator);
            clickJS(locator);
        }
        
    }

    public void goToCart()
    {
        ScrollToElement(cartButton);
        clickJS(cartButton);
       
    }

    public void chechkout()
    {
        ScrollToElement(checkoutButton);
        Type(firstname,"Şeyma Nur");
        Type(lastname,"Karaoğlan");
        Type(postalcode,"34000");
        
        clickJS(checkoutButton);
        Thread.Sleep(5000);
        
        clickJS(finishButton);
    }

    public bool finishheaderdisplay()
    {
        if (driver.FindElement(finishHeader).Displayed)
        {
            return true;
        }

        return false;
    }
}