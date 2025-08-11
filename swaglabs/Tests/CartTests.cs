using swaglabs.Pages;
using swaglabs.Utils;

namespace swaglabs.Tests;
[TestFixture]
public class CartTests : TestBase
{
    private ProductsPage productsPage = new ProductsPage();
    private LoginPage loginPage = new LoginPage();
    private CartPage cartPage = new CartPage();
    
    
    [Test,Category("Step3")]
    public void DeleteToCartTest()
    {
        loginPage.login(username, password);
        //productsPage.addToCart("Sauce Labs Fleece Jacket");
        int countbefore = productsPage.IsProductAddedToCart();
        Thread.Sleep(5000);
        
        
        cartPage.goToCart();
        cartPage.deleteToCart("Sauce Labs Fleece Jacket");
        Thread.Sleep(5000);
        int countafter = productsPage.IsProductAddedToCart();
        Assert.That(countafter, Is.LessThan(countbefore));
        
    }

    [Test, Category("Step4")]
    public void checkoutTest()
    {
        cartPage.chechkout();
        var istrue = cartPage.finishheaderdisplay();
            Assert.That(istrue,Is.True);
        
    }
}