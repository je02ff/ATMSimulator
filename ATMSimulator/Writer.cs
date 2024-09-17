namespace ATMSimulator;

public class Writer(int origCol, int origRow)
{
    private int _origCol = origCol;
    private int _origRow = origRow;

    public void WriteAt(string s, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(_origCol + x, _origRow + y);
            Console.Write(s);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }
}