

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
            
        }

		
		
		 
		
		
		
        public virtual string PollSensors()
        {
				string output="";

			 

            foreach (ISensor sensor in sensors)
            {
                if (sensor.IsTriggered())
                {
                     output+= "A " + sensor.GetSensorType() + " sensor was triggered at " + sensor.GetLocation()+"\n";
                }
                else
                {

                     output+= "Polled " + sensor.GetSensorType() + " at " + sensor.GetLocation() + " successfully\n";
                }
			
            }
			return output;




        
        }
    }

	public interface  IControlUnit<T>
		{
			public List<T> sensors { get; set; }
			void PollSensors();
			
		}
public	interface ISafetyControlUnit<T> : IControlUnit<T>
		{
			void GetBatteryPercentage();


		}

	public interface ISecurityControlUnit<T> : IControlUnit<T>
		{
			
		

		}
	
   public interface ISensor
    {
		double TRIGGER  { get;   }
         bool IsTriggered();
        string GetLocation();
        string GetSensorType();
		  string Location { get; set; }
    }
  public  interface IBatterySensor : ISensor
    {

		    double BatteryPercentage { get;  set; }
         void UseBattery();
		  double SINGLE_USAGE_DECREMENT  { get;   }
    }

   public interface ICableSensor : ISensor
    {


    }
	
	public interface  ILocationProvider
    {
		public string Location { get; set; }

    }


	 public class SensorInAuditorium : ILocationProvider
    {
         public string Location { get; set; }
	   public SensorInAuditorium()
        {
            Location = "the auditorium";
        }

    }
	
	 public class SensorLobby1stFloor : ILocationProvider
    {
		public string Location { get; set; }
        public SensorLobby1stFloor()
        {
            Location = "the Lobby 1st floor";
        }

    }

	 public class SensorAtFrontDoor : ILocationProvider
    { public string Location { get; set; }
        public SensorAtFrontDoor()
        {
            Location = "the front door";
        }

    }
}
