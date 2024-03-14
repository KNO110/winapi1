using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

    static void Main()
    {
        Console.WriteLine("Введи название окна, или его часть:");
        string partialWindowTitle = Console.ReadLine();

        Process[] processes = Process.GetProcesses();
        IntPtr hWnd = IntPtr.Zero;

        foreach (Process process in processes)
        {
            if (!string.IsNullOrEmpty(process.MainWindowTitle) && process.MainWindowTitle.Contains(partialWindowTitle))
            {
                hWnd = process.MainWindowHandle;
                break;
            }
        }

        if (hWnd != IntPtr.Zero)
        {
            Console.WriteLine($"Окно \"{partialWindowTitle}\" найдено. Введи новое название для этого окна:");
            string newTitle = Console.ReadLine();

            SendMessage(hWnd, 0x000C, 0, newTitle);
        }
        else
        {
            Console.WriteLine($"Окно \"{partialWindowTitle}\" не ром пом пом.");
        }
    }
}
