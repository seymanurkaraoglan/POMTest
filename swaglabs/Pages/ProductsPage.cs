using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace swaglabs.Pages;

public class ProductsPage : BasePage
{
    private By addToCartButton = By.XPath("(//button[@class='btn_primary btn_inventory'])[last()]");
    public By cartButton = By.ClassName("shopping_cart_badge");
    
    public CartPage addToCart(params string[] productNames)
    {
        foreach (var productName in productNames)
        {
            var locator = By.XPath(
                $"//div[@class='inventory_item_name' and text()='{productName}']" +
                "/ancestor::div[contains(@class,'inventory_item')]//button"
            );
            ScrollToElement(locator);
            clickJS(locator);
        }
        return new  CartPage();
    }

    public int IsProductAddedToCart()
    {
        IList<IWebElement> badges = driver.FindElements(By.ClassName("shopping_cart_badge"));
        if(badges.Count > 0)
        {
            return int.Parse(badges[0].Text);
        }

        return 0;
    }

    
    
    
    

}