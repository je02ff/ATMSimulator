namespace ATMSimulator.Model.objects;

public class User
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int AccountNumber { get; init; }
    public int Pin { get; init; }
    public Decimal Balance { get; init; }
}