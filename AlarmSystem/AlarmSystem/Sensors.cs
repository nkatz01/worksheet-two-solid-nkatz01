using System;
namespace AlarmSystem
{
    public class FireSensor : IBatterySensor
    {
        public bool IsTriggered { get; set; }
        public double BatteryPercentage { get; set; }

        public FireSensor()
        {
           
            IsTriggered = false;
            BatteryPercentage = double(100);
        }



        public bool IsTriggered() { 
         Random RandomGen = new Random();          //https://stackoverflow.com/questions/37858551/implement-percent-chance-in-c-sharp
            int randomValue = RandomGen.Next(100);
            if (randomValue <= 10)
            {
                IsTriggered = true;
            }
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

    public class SmokeSensor : IBatterySensor
    {
        public bool IsTriggered { get; set; }

        public SmokeSensor()
        {
              Random RandomGen = new Random();          
            int randomValue = RandomGen.Next(100);
            if (randomValue <=10 ) { 
             IsTriggered = true;
            }
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

    public class MotionSensor : ICableSensor
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
