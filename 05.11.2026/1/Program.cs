using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Console.WriteLine($"Имя - {currentProcess.ProcessName}");
        Console.WriteLine($"ID - {currentProcess.Id}");
        Console.WriteLine($"Время - {currentProcess.StartTime}");
        Console.WriteLine($"Использование вирт (памяти) -  {currentProcess.VirtualMemorySize64 / 1024 / 1024} MB");
        Console.WriteLine(new string('-', 40));

        
        Console.WriteLine("Топ 5 процессов по объему - ");
        Process[] allProcesses = Process.GetProcesses();
        
        var top = allProcesses
                            .OrderByDescending(p => p.WorkingSet64)
                            .Take(5);
        foreach(Process process in top)
        {
            Console.WriteLine(
                $"Имя -  {process.ProcessName}, " + $"id -  {process.Id}, " + $"Память - {process.WorkingSet64 / 1024 / 1024} мб"
            );
        }

        foreach(Process process in allProcesses)
        {
            process.Dispose();
        }
    }
}
