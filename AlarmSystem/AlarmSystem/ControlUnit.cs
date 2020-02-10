using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    public class ControlUnit
    {
        public void PollSensors()
        {
            List<ISensor> sensors = new List<ISensor>();
            sensors.Add(new FireSensor());
            sensors.Add(new SmokeSensor());

            foreach (ISensor sensor in sensors)
            {
                if (sensor.IsTriggered)
                {
                    Console.WriteLine("A " + sensor.GetSensorType() + " sensor was triggered at " + sensor.GetLocation());
                }
                else
                {
                    Console.WriteLine("Polled " + sensor.GetSensorType() + " at " + sensor.GetLocation() + " successfully");
                }
            }
        }
    }

    interface ISensor
    {
        bool IsTriggered { get; set; }
        string GetLocation();
        string GetSensorType();
     }
	   interface IbatterySensor
    {
       
       
        double GetBatteryPercentage();
    }
		   interface IcableSensor : ISensor
    {
       
       
    }
}
