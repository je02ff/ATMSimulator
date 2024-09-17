namespace ATMSimulator.Test;

public class ValidateTest
{
    [Fact]
    public void Test1()
    {
        // Arrange
        List<string> invalidAccountStrings = ["123", "123345a"];
        string validAccount = "123456";
        
        // Act
    
        // Assert
        Assert.True(ATMSimulator.Validate.IsValidAccountNumber(validAccount));
        foreach (var str in invalidAccountStrings)
        {
            Assert.False(ATMSimulator.Validate.IsValidAccountNumber(str));
        }
    }
}