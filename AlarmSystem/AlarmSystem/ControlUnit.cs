#define POLL

using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    public class ControlUnit<T>
    {


        public List<T> sensors { get; set; }

        public ControlUnit(List<T> sensors)
        {

            this.sensors = sensors;
            //Console.WriteLine(sensors);
        }

		
		
		 
		
		
		
        public virtual void PollSensors()
        {



#if ISOLATE && POLL
            foreach (ISensor sensor in sensors)
            {
                if (sensor.IsTriggered)//&& !(sensor is ICableSensor) )
                {
                    Console.WriteLine("A " + sensor.GetSensorType() + " sensor was triggered at " + sensor.GetLocation());
                }
                else
                {

                    Console.WriteLine("Polled " + sensor.GetSensorType() + " at " + sensor.GetLocation() + " successfully");
                }
				 // Console.WriteLine(  sensor is IBatterySensor );
				//if (sensor  is IBatterySensor){
					 //Console.WriteLine(  sensor is ICableSensor );
				  
				//}
            }


#endif

           // Console.WriteLine("I'm still working");
        }
    }

	interface  IControlUnit<T>
		{
			public List<T> sensors { get; set; }
			void PollSensors();
			
		}
	interface ISafetyControlUnit<T> : IControlUnit<T>
		{
			void GetBatteryPercentage();


		}

	interface ISecurityControlUnit<T> : IControlUnit<T>
		{
			
		

		}
	
    interface ISensor
    {
        bool IsTriggered { get; set; }
        string GetLocation();
        string GetSensorType();
		  string Location { get; set; }
    }
    interface IBatterySensor : ISensor
    {

		    double BatteryPercentage { get;  set; }
         void UseBattery();
		 
    }

    interface ICableSensor : ISensor
    {


    }
	
	public interface  ILocationProvider
    {
		public string Location { get; set; }

    }

#if DEVMOD
	
#endif
	 internal class SensorInAuditorium : ILocationProvider
    {
         public string Location { get; set; }
	   public SensorInAuditorium()
        {
            Location = "the auditorium";
        }

    }
	
	 internal class SensorLobby1stFloor : ILocationProvider
    {
		public string Location { get; set; }
        public SensorLobby1stFloor()
        {
            Location = "Lobby 1st floor";
        }

    }

	 internal class SensorAtFrontDoor : ILocationProvider
    { public string Location { get; set; }
        public SensorAtFrontDoor()
        {
            Location = "the front door";
        }

    }
}
