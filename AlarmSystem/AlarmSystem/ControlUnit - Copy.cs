#define POLL
using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    public class ControlUnit<T>
	{
		
		 
		public	List<T> sensors  { get; set; }
	
		 public ControlUnit(List<T> sensors){
			
			 this.sensors = sensors;
			//Console.WriteLine(sensors);
		} 
		
		
        public void PollSensors()
        {
          
			  
			 
#if ISOLATE && POLL
             foreach (ISensor sensor in sensors)
            { 
                if (sensor.IsTriggered )//&& !(sensor is IcableSensor) )
                {
                    Console.WriteLine("A " + sensor.GetSensorType() + " sensor was triggered at " + sensor.GetLocation());
                }
                else
                {
					
                    Console.WriteLine("Polled " + sensor.GetSensorType() + " at " + sensor.GetLocation() + " successfully");
                }
            }
#endif
			 
			Console.WriteLine("I'm still working");
        }
    }

     interface ISensor
    {
        bool IsTriggered { get; set; }
        string GetLocation();
        string GetSensorType();
     }
	    interface IbatterySensor : ISensor
    {
       
       
        double GetBatteryPercentage();
    }
	 	   interface IcableSensor : ISensor
    {
       
       
    }
}
