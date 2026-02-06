using System;
using System.Timers;
class TimerConsole
{
    // timer variable, fires every 2 seconds (2000 milliseconds)
    private static System.Timers.Timer aTimer = new System.Timers.Timer(2000.0);

    static void Main(string[] args)
    {
        for(int idx = 0; idx < args.Length; idx++)
        {
            Console.WriteLine("arg[" + idx.ToString() + "] = " + args[idx] + "\n");
        }
        // if an argument was passed in, try converting it to an integer
        // if it is an integer, use that for the timer interval
        try
        {
            Console.WriteLine("Interval set to " + args[0] + "ms\n");
            SetTimer(Convert.ToDouble(args[0]));
        }
        // either no argument, or not an integer - set to default of 2000ms
        catch
        {
            Console.WriteLine("Interval set to default value of 2000ms\n");
            SetTimer(2000);
        }
        // start timer

        Console.WriteLine("\nPress the Enter key to exit the application...\n");
        Console.WriteLine($"The application started at {DateTime.Now:HH:mm:ss.fff}");
        Console.ReadLine(); // Wiat for user input, keeps the console app running
        // after user presses enter, clean up and exit
        aTimer.Stop();
        aTimer.Dispose();
        Console.WriteLine("Terminating the application...");
    }

    private static void SetTimer(double timerInterval)
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(timerInterval);
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