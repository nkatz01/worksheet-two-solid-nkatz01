using System;
namespace AlarmSystem
{
    public class FireSensor : IBatterySensor
    {
        public bool IsTriggered { get; set; }
		 public string Location { get; set; }
		public double BatteryPercentage { get; private set; }

        public FireSensor()
        {	 
            IsTriggered = false;
        }


        public string GetLocation()
        {
           if (Location!=null)
          return Location;
			return String.Empty;
        }
		
		  public void SetLocation(string Location)
        {
            this.Location = Location; // convention is to use the .NET class for properties/methods/constants
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
        public SmokeSensor()
        {
			
			
            IsTriggered = false;
        }

        public string GetLocation()
        {
			if (Location!=null)
          return Location;
			return String.Empty;
			
        }
		
		  public void SetLocation(string Location)
        {
            this.Location = Location; // convention is to use the .NET class for properties/methods/constants
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
