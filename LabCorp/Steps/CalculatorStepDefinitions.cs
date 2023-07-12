

using Microsoft.Extensions.Configuration;

namespace LabCorp.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly IConfiguration _configuration;

    public CalculatorStepDefinitions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        Console.WriteLine("Given statement------");
        string browser = _configuration["MySettings:Browser"];
        string webEnvironment = _configuration["MySettings:WebEnvironment"];
        Console.WriteLine(browser);
        Console.WriteLine(webEnvironment);
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        Console.WriteLine("Method");
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        Console.WriteLine("Method");
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        Console.WriteLine("Method");
    }
}