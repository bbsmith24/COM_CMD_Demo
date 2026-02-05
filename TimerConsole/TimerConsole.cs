using System;
using System.Timers;
class TimerConsole
{
    // timer variable, fires every 2 seconds (2000 milliseconds)
    private static System.Timers.Timer aTimer = new System.Timers.Timer(2000.0);

    static void Main(string[] args)
    {
        // start timer
        SetTimer();

        Console.WriteLine("\nPress the Enter key to exit the application...\n");
        Console.WriteLine($"The application started at {DateTime.Now:HH:mm:ss.fff}");
        Console.ReadLine(); // Wiat for user input, keeps the console app running
        // after user presses enter, clean up and exit
        aTimer.Stop();
        aTimer.Dispose();
        Console.WriteLine("Terminating the application...");
    }

    private static void SetTimer()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer.
        // adds the function (OnTimedEvent) to the handler for aTimer
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true; // Repeat the event every interval
        aTimer.Enabled = true; // Start the timer
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        // output message to console when the event is raised
        Console.WriteLine($"The Elapsed event was raised at {e.SignalTime:HH:mm:ss.fff}");
    }
}