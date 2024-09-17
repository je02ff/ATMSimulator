using System;

class Program
{
    static void Main()
    {
        // Clear the console
        Console.Clear();

        // Define the dimensions of the box
        int boxWidth = 40;
        int boxHeight = 3;
        
        // Draw the initial box
        DrawBox(boxWidth, boxHeight);

        // Move the cursor inside the box
        Console.SetCursorPosition(1, 1);

        // Read user input
        string userInput = "";
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            // Handle input
            if (key.Key == ConsoleKey.Enter)
            {
                // End input on Enter key
                break;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                // Handle backspace
                if (userInput.Length > 0)
                {
                    userInput = userInput.Substring(0, userInput.Length - 1);
                    Console.SetCursorPosition(1, 1);
                    Console.Write(new string(' ', boxWidth - 2));
                    Console.SetCursorPosition(1, 1);
                }
            }
            else
            {
                // Handle regular characters
                userInput += key.KeyChar;
            }

            // Redraw the user input inside the box
            Console.Write(userInput);
        }

        // Clear the input area and end
        Console.SetCursorPosition(0, boxHeight + 1);
        Console.WriteLine($"You entered: {userInput}");
    }

    static void DrawBox(int width, int height)
    {
        // Draw the top border
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(new string('-', width));

        // Draw the middle rows
        for (int i = 0; i < height - 2; i++)
        {
            Console.SetCursorPosition(0, i + 1);
            Console.Write('|');
            Console.SetCursorPosition(width - 1, i + 1);
            Console.Write('|');
        }

        // Draw the bottom border
        Console.SetCursorPosition(0, height - 1);
        Console.WriteLine(new string('-', width));
    }
}
