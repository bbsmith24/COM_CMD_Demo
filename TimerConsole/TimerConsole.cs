using System;
using System.Timers;
class TimerConsole
{
    private static System.Timers.Timer aTimer = new System.Timers.Timer(2000.0);

    static void Main(string[] args)
    {
        SetTimer();

        Console.WriteLine("\nPress the Enter key to exit the application...\n");
        Console.WriteLine($"The application started at {DateTime.Now:HH:mm:ss.fff}");
        Console.ReadLine(); // Keep the console app running

        aTimer.Stop();
        aTimer.Dispose();
        Console.WriteLine("Terminating the application...");
    }

    private static void SetTimer()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer.
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true; // Repeat the event every interval
        aTimer.Enabled = true; // Start the timer
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine($"The Elapsed event was raised at {e.SignalTime:HH:mm:ss.fff}");
        // Add your recurring task logic here (e.g., logging, checking a database)
    }
}