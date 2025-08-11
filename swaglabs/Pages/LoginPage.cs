using OpenQA.Selenium;

namespace swaglabs.Pages;

public class LoginPage : BasePage
{
   
    
    private By usernameField = By.Id("user-name");
    private By passwordField = By.Id("password");
    private By loginButton = By.Id("login-button");
    private By errorMessage = By.CssSelector("#login_button_container h3");
    private By logoutButton = By.ClassName("bm-burger-button");
    private By logoutLink = By.Id("logout_sidebar_link");
    
    private By loginForm = By.ClassName("login_wrapper-inner");
    public ProductsPage login(string username, string password)
    {
        Type(usernameField,username);
        Type(passwordField,password);
        return Click(loginButton);
       
    }

    public string getErrorMessage()
    {
       string msg = GetText(errorMessage);
       return msg;
    }

    public void logout()
    {
        clickJS(logoutButton);
        clickJS(logoutLink);
        
    }
    
    public bool isLoginFormPresent(){
        return find(loginForm).Enabled;
    }
    
}