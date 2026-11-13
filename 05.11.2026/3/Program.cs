using System;
using System.Diagnostics;
using System.Threading;
class Program
{
    static void Main()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
          FileName = "notepad.exe",
          Arguments = "timeout /t 60",
        };
        try
        {
            using(Process childProcess = Process.Start(startInfo))
            {
                Process.Start("notepad.exe");
                Console.WriteLine($"Процесс запущен");
                if (childProcess.WaitForExit(3000))
                {
                    Console.WriteLine($"Процесс завершился");
                }
                else
                {
                    Console.WriteLine($"Процесс не завершился");
                    childProcess.Kill();
                    childProcess.WaitForExit();
                    Console.WriteLine($"Процесс зевершился");
                }
            };
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ошибка - {ex.Message}");
        }
    }
}