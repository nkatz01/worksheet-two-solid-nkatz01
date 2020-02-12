using System;
namespace AlarmSystem
{
    public class FireSensor : IBatterySensor
    {
        public bool IsTriggered { get; set; }
		 public string Location { get; set; }
		public double BatteryPercentage { get; private set; }

        public FireSensor(ILocationProvider provider)
        {	 
            IsTriggered = false;
			Location=provider.Location;
        }


        public string GetLocation()
        {
          
          return Location;
			 
        }
		
	 

        public string GetSensorType()
        {
            return String.Empty;
        }

        public double GetBatteryPercentage()
        {
			if (BatteryPercentage<0.10)
				BatteryPercentage=1.00;
            return BatteryPercentage-0.10;    }
    }

    public class SmokeSensor : IBatterySensor
    {	
        public bool IsTriggered { get; set; }
		public string Location { get; set; }
		public double BatteryPercentage { get; private set; }
		
        public SmokeSensor(ILocationProvider provider)
        {
            IsTriggered = false;
			Location=provider.Location;
        }

        public string GetLocation()
        {
			 
          return Location;
			 
			
        }
		
		 

        public string GetSensorType()
        {
            return String.Empty;
        }

        public double GetBatteryPercentage()
        {		if (BatteryPercentage<0.20)
				BatteryPercentage=1.00;
             return BatteryPercentage-0.20; 
        }
    }

    public class MotionSensor : ICableSensor
    {	public string Location { get; set; }
        public bool IsTriggered { get; set; }

        public MotionSensor(ILocationProvider provider)
        {
            IsTriggered = false;
			Location=provider.Location;
        }

        public string GetLocation()
        {
            return Location;
        }

        public string GetSensorType()
        {
            return String.Empty;
        }


    }
}
