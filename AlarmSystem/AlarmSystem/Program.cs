using System;

namespace AlarmSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlUnit controlUnit = new ControlUnit();

            string input = string.Empty;
            while (input.Equals("exit"))
            {
                Console.WriteLine("Type \"poll\" to poll all sensors once or \"exit\" to exit");
                input = Console.ReadLine();
                if (input.Equals("poll"))
                {
                    controlUnit.PollSensors();
                }
            }
        }
    }
}
