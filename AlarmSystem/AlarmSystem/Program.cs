//#define ASK
//#define DEVMOD
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
				
			SecurityControlUnit<IcableSensor> securityControlUnit = new SecurityControlUnit<IcableSensor>(new List<IcableSensor>{ new MotionSensor()});	
			#region
#if DEVMOD			
				
#endif	
 #endregion
  TimeSpan  now = DateTime.Now.TimeOfDay;
				TimeSpan nowTrimmed = new TimeSpan(now.Hours, now.Minutes, now.Seconds);
TimeSpan FROM = new  TimeSpan(22, 0, 0);
				TimeSpan UNTIL = new TimeSpan(06, 0, 0);
  Console.WriteLine(nowTrimmed  );


			
#if ISOLATE	&& ASK		
			string input ="exit";
			
		
            while (input.Equals("exit"))
            {
				
                Console.WriteLine("Type \"poll\" to poll all sensors once or \"exit\" to exit");
                input = Console.ReadLine();
                if (input.Equals("poll"))
                {
				
                   controlUnit.PollSensors(); //uncomment
                 }
            }
 #endif
				  

			 controlUnit.PollSensors(); //remove
			securityControlUnit.PollSensors(); //remove
			}

    }
}
