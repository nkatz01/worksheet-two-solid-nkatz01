#define POLL
#define DEVMOD
using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    public class SecurityControlUnit<T> : ControlUnit<T>  where  T : IcableSensor
	{
#if DEVMOD

		//TimeSpan start = new TimeSpan(10, 0, 0); //10 o'clock
//TimeSpan end = new TimeSpan(12, 0, 0); //12 o'clock
//TimeSpan now = DateTime.Now.TimeOfDay;



  public override void PollSensors()
        {
			 TimeSpan  now = DateTime.Now.TimeOfDay;
				TimeSpan nowTrimmed = new TimeSpan(now.Hours, now.Minutes, now.Seconds);
				  
				 
				TimeSpan FROM = new  TimeSpan(22, 0, 0);
				TimeSpan UNTIL = new TimeSpan(06, 0, 0);
			
			if (( nowTrimmed >  FROM) || (nowTrimmed< FROM && nowTrimmed <= UNTIL)){
							Console.WriteLine("You're calling me from here");

				base.PollSensors();
			}
		}
     
#endif
		 
		 
	
		 public SecurityControlUnit(List<T> sensors) :base(sensors){
			//Console.WriteLine(sensors);
		} 
		
		

    
}
}
