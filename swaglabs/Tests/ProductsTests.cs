using swaglabs.Pages;
using swaglabs.Utils;
using NUnit.Framework;

namespace swaglabs.Tests;

[TestFixture]
public class ProductsTests : TestBase
{
    ProductsPage productsPage = new ProductsPage();
    LoginPage loginPage = new LoginPage();
    
    [Test,Category("Step2")]
    public void addToCartTest()
    {
        loginPage.login(username,password);
        int countbefore = productsPage.IsProductAddedToCart();
        productsPage.addToCart("Sauce Labs Fleece Jacket", "Sauce Labs Onesie");
        Thread.Sleep(2000);
        int countafter = productsPage.IsProductAddedToCart();
        Thread.Sleep(2000);
        Assert.That(countafter, Is.GreaterThan(countbefore));
       // Assert.That(productsPage.IsProductAddedToCart(),Is.True,"Ürün sepete eklenemedi");
    }

    
}