using System;
namespace AlarmSystem
{
    public class FireSensor : IbatterySensor
    {
        public bool IsTriggered { get; set; }

        public FireSensor()
        {
            IsTriggered = false;            
        }


        public string GetLocation()
        {
            return String.Empty; // convention is to use the .NET class for properties/methods/constants
        }

        public string GetSensorType()
        {
            return String.Empty;
        }

        public double GetBatteryPercentage()
        {
            return -1.0;
        }
    }

    public class SmokeSensor : IbatterySensor
    {
        public bool IsTriggered { get; set; }

        public SmokeSensor()
        {
            IsTriggered = false;
        }

        public string GetLocation()
        {
            return String.Empty;
        }

        public string GetSensorType()
        {
            return String.Empty;
        }

        public double GetBatteryPercentage()
        {
            return -1.0;
        }
    }
	
	public class MotionSensor : IcableSensor
    {
        public bool IsTriggered { get; set; }

        public MotionSensor()
        {
            IsTriggered = false;
        }

        public string GetLocation()
        {
            return String.Empty;
        }

        public string GetSensorType()
        {
            return String.Empty;
        }

        
    }
}
