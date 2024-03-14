using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("kernel32.dll")]
    public static extern bool Beep(int frequency, int duration);

    [DllImport("user32.dll")]
    public static extern bool MessageBeep(uint uType);

    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            Beep(500, 500);
            Thread.Sleep(200);
        }
        MessageBeep(0);
    }
}
