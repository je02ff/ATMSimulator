using System.Diagnostics;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

[DllImport("libc")]
static extern int system(string exec);


system(@"printf '\e[8;50;100t'"); //adjust the 50 and 100t for whatever size you are wanting.
system(@"printf '\e[3;0;0t'"); // moves terminal to top left

while (true)
{
    var someText = Console.ReadLine();
    Console.WriteLine(someText);
}