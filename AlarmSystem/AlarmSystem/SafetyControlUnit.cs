#define POLL
#define DEVMOD
using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    class SafetyControlUnit<T> : ControlUnit<T> where T : IBatterySensor
    {
#if DEVMOD





        public void GetBatteryPercentage()
        {
            foreach (IBatterySensor sensor in sensors)
			{
			 Console.WriteLine(sensor.GetSensorType() + "Battery power of the Sensor " + sensor.GetLocation()+" is at " + Math.Round(sensor.BatteryPercentage,2) + "percent");
			}
        }
		
		 public override void PollSensors()
        {
			 foreach (IBatterySensor sensor in sensors)
            
			{
				sensor.UseBattery();
				
			
			}

			base.PollSensors();
		}

#endif



        public SafetyControlUnit(List<T> sensors) : base(sensors)
        {
            //Console.WriteLine(sensors);
        }




    }
}
