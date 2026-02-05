using System.Diagnostics;
using System.IO;
using System.IO.Ports;

namespace ConsoleApp2
{
    internal class COM_CMD_Demo
    {
        static void Main(string[] args)
        {
            // list available serial ports
            Console.WriteLine("Available Ports");
            String[] ports = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine(ports[i]);
            }
            // set up port to read from - you'll need to change the port name and possibly baud rate to match
            System.IO.Ports.SerialPort port = new SerialPort("COM17", 115200, Parity.None, 8, StopBits.One);
            // open the serial port
            port.Open();
            // this will be the process that monitors the GPU
            Process process = new Process();
            process.StartInfo.FileName = "TimerConsole.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            // run until the console closes
            while (true)
            {
                // this is the string that will be read from COM or command
                // '?' allows it to be null (empty)
                String? read = "";
                // wait for something on the port
                if (port.BytesToRead > 0)
                {
                    // read up to the end of the line
                    read = port.ReadLine();
                    // output current system time (the timestamp) to console, followed by a <tab>
                    Console.Write(System.DateTime.Now.ToString());
                    Console.Write("\tCOM\t");
                    // output the line read from the COM port
                    Console.WriteLine(read);
                }
                // read a line from the process
                read = process.StandardOutput.ReadLine();
                if (read != null)
                {
                    Console.Write(System.DateTime.Now.ToString());
                    Console.Write("\tCMD\t");
                    Console.WriteLine(read);
                }
            }
        }
    }
}
