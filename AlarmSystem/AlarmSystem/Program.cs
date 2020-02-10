using System.Collections.Generic;
using System;
//dotnet run
namespace AlarmSystem
{
    class Program
    {
        static void Main(string[] args)
        {
			 // List<ISensor> sensors = new List<ISensor>();
           // sensors.Add(new FireSensor());
         

			//sensors.Add(new SmokeSensor());
			

			//sensors.Add(new MotionSensor());
			
            ControlUnit<ISensor> controlUnit = new ControlUnit<ISensor>(new List<ISensor>{
				new FireSensor(),
				new SmokeSensor(),
				new MotionSensor()
				
				});//pass sensors here
			 //Console.WriteLine(string.Join('-', args)); @(1,2,3) or "[1,2,3"
           // string input =args[0]; //string.Empty;
			
#if ISOLATE			
			string input ="exit";
			
		
            while (input.Equals("exit"))
            {
				
                Console.WriteLine("Type \"poll\" to poll all sensors once or \"exit\" to exit");
                input = Console.ReadLine();
                if (input.Equals("poll"))
                {
				
                 //   controlUnit.PollSensors(); uncomment
                 }
            }
 #endif
				  

				controlUnit.PollSensors(); //remove
			}

    }
}
