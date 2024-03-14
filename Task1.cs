using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    static void Main()
    {
        string name = "ak1ra";
        string message = $"Привет, я {name}!";

        MessageBox(IntPtr.Zero, message, "Информация", 0);
        MessageBox(IntPtr.Zero, $"Меня зовут {name}. Я ваш помощник.", "Информация", 0);
    }
}
