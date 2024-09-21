using ATMSimulator.Model.objects;
using Microsoft.Data.Sqlite;

namespace ATMSimulator;

public class DataAccess
{
    public static User? GetUser(int accountNumber)
    {
        User? user = null;
        using (var connection =
               new SqliteConnection("Data Source=/Users/jeffroden/devRoot/ATMSimulator/ATMSimulator/Atm.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();

            command.CommandText =
                @"
                    SELECT id, firstName, lastName, accountNumber, pin, balance
                    FROM users
                    WHERE accountNumber = $accountNumber
                ";
            command.Parameters.AddWithValue("$accountNumber", accountNumber);
            
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        AccountNumber = reader.GetInt32(3),
                        Pin = reader.GetInt32(4),
                        Balance = reader.GetDecimal(5)
                    };
                }
            }
        }
        return user;
    }
}