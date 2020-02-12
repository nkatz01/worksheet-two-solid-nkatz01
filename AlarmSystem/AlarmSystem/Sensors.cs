using System;
namespace AlarmSystem
{
    public class FireSensor : IBatterySensor
    {
        public bool IsTriggered { get; set; }
		 public string Location { get; set; }
		public double BatteryPercentage { get;  set; }

        public FireSensor(ILocationProvider provider)
        {	 
            IsTriggered = false;
			Location=provider.Location;
			BatteryPercentage=1.00;
        }


        public string GetLocation()
        {
          
          return Location;
			 
        }
		
		
	/* 	public static Random RandomGen = new Random();
 
int clickPercentage = 70;
for (int i = 0; i < 100; i++)
{
    int randomValueBetween0And99 = RandomGen.Next(100);
    if (randomValueBetween0And99 < clickPercentage)
    {
        //do 70% times
    }
} */
		
	 

        public string GetSensorType()
        {
            return String.Empty;
        }

        public void UseBattery()
        {
			if (BatteryPercentage<0.10){
			BatteryPercentage=1.00;}
              BatteryPercentage-=0.10;     
		}
	}
	
    public class SmokeSensor : IBatterySensor
    {	
        public bool IsTriggered { get; set; }
		public string Location { get; set; }
		public double BatteryPercentage { get;  set; }
		
        public SmokeSensor(ILocationProvider provider)
        {
            IsTriggered = false;
			Location=provider.Location;
			BatteryPercentage=1.00;
        }

        public string GetLocation()
        {
			 
          return Location;
			 
			
        }
		
		 

        public string GetSensorType()
        {
            return String.Empty;
        }

        public void UseBattery()
        {		if (BatteryPercentage<0.20){
				BatteryPercentage=1.00;}
				
               BatteryPercentage-=0.20; 
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
