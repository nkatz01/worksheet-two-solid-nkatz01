using System;
//dotnet run
namespace AlarmSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlUnit controlUnit = new ControlUnit();//pass sensors here
			 //Console.WriteLine(string.Join('-', args)); @(1,2,3) or "[1,2,3"
           // string input =args[0]; //string.Empty;
			string input ="exit";
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
