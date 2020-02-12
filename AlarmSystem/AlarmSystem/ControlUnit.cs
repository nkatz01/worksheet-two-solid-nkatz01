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
            }


#endif

           // Console.WriteLine("I'm still working");
        }
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


        double GetBatteryPercentage();
    }

    interface ICableSensor : ISensor
    {


    }
	
	 interface  ILocationProvider
    {
		string Location { get; set; }

    }
	
	 interface ILocationAttacher
    {
        ILocationProvider LocationProvider { get; set; }
		ISensor Receiver { get; set; }
		
        void Attach();
    }

	
	
	
	internal class StandardLocationExtractor : ILocationAttacher
    {
        public StandardLocationExtractor(ILocationProvider provider, ISensor receiver)
        {
            LocationProvider = provider;
			Receiver = receiver;
        }

        public ILocationProvider LocationProvider { get; set; }
		public ISensor Receiver { get; set; }
		
        public void Attach()
        {
            if (LocationProvider == null || Receiver == null )
            {
                throw new Exception($"You must set the property LocationProvider and Receiver of class: {GetType()}");
            }

            Receiver.Location=LocationProvider.Location;
        }
    }
	
	 internal class SensorInAuditorium : ILocationProvider
    {
        public SensorInAuditorium()
        {
            Location = "In the auditorium";
        }

        public string Location { get; set; }
    }
	
	 internal class SensorLobby1stFloor : ILocationProvider
    {
        public SensorLobby1stFloor()
        {
            Location = "Lobby 1st floor";
        }

        public string Location { get; set; }
    }

	 internal class SensorAtFrontDoor : ILocationProvider
    {
        public SensorAtFrontDoor()
        {
            Location = "At the front door";
        }

        public string Location { get; set; }
    }
}
