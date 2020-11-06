
using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    public class SafetyControlUnit<T> : ControlUnit<IBatterySensor>, ISafetyControlUnit<IBatterySensor> where T : IBatterySensor
    {
        public string GetBatteryPercentage()
        {
            string output = "";
            foreach (IBatterySensor sensor in sensors)
            {
                output += "Battery power of the Sensor at " + sensor.GetLocation() + " of type " + sensor.GetSensorType() + " is at " + Math.Round(sensor.BatteryPercentage, 2) + "percent\n";
            }
            return output;
        }

        public SafetyControlUnit(List<IBatterySensor> sensors) : base(sensors)
        {

        }

        public override string PollSensors()
        {
            string output = "";
            foreach (IBatterySensor sensor in sensors)

            {
                sensor.UseBattery();

            }
            output += base.PollSensors();
            return output;
        }


        


    }
}
