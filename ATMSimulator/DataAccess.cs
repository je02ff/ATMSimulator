

using Microsoft.Data.Sqlite;

namespace ATMSimulator;

public class DataAccess
{
    public void GetUser(int accountNumber)
    {
        using (var connection = new SqliteConnection("Data Source=/Users/jeffroden/devRoot/ATMSimulator/ATMSimulator/Atm.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            
            command.CommandText =
                @"
                    SELECT firstName, lastName, balance
                    FROM users
                    WHERE accountNumber = $accountNumber
                ";
            command.Parameters.AddWithValue("$accountNumber", accountNumber);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);

                    Console.WriteLine($"Hello, {name}!");
                }
            }
        }
    }
}