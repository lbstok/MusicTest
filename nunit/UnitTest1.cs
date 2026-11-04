using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebTests;

public class RecordsPageTests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new FirefoxDriver();
        driver.Navigate().GoToUrl("https://lolasse-fddfcqecamgrcjff.germanywestcentral-01.azurewebsites.net" /);
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void Page_Has_Right_Title()
    {
        Assert.That(driver.Title, Is.EqualTo("Records Collection"));
    }

    [Test]
    public void Page_Shows_Welcome_Heading()
    {
        var heading = driver.FindElement(By.TagName("h1"));
        Assert.That(heading.Text, Is.EqualTo("Welcome to My Records Collection"));
    }
}