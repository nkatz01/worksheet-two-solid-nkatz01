using System;
 namespace AlarmSystem
{
    public class FireSensor : IBatterySensor
<<<<<<< HEAD
    {
        public bool IsTriggered { get; set; }
        public double BatteryPercentage { get; set; }

        public FireSensor()
        {
           
            IsTriggered = false;
            BatteryPercentage = double(100);
=======
    {	 public double SINGLE_USAGE_DECREMENT  { get;   }
		public double TRIGGER  { get;   }
 		 public string Location { get; set; }
		public double BatteryPercentage { get;  set; }

        public FireSensor(ILocationProvider provider)
        {	 
            TRIGGER = 5;
			Location=provider.Location;
			BatteryPercentage=1.00;
			SINGLE_USAGE_DECREMENT=0.10;
>>>>>>> ea2d2368d7e20710b63b76d77dacbcb78f600d30
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
          
          return Location;
			 
        }
		
		
	
			public bool IsTriggered() {
				 
				 return this.IsTriggeredDefault();
			 }

	 

        public string GetSensorType()
        {
            return this.GetType().ToString();
        }

        public void UseBattery()
        {
			 
              BatteryPercentage-=SINGLE_USAGE_DECREMENT;     
		}
	}
	
    public class SmokeSensor : IBatterySensor
    {
public double TRIGGER  { get;   }		
	public  double SINGLE_USAGE_DECREMENT  { get;   }
		public string Location { get; set; }
		public double BatteryPercentage { get;  set; }
		
        public SmokeSensor(ILocationProvider provider)
        {
<<<<<<< HEAD
              Random RandomGen = new Random();          
            int randomValue = RandomGen.Next(100);
            if (randomValue <=10 ) { 
             IsTriggered = true;
            }
            IsTriggered = false;
=======
            TRIGGER = 10;
			Location=provider.Location;
			BatteryPercentage=1.00;
			SINGLE_USAGE_DECREMENT=0.20;
>>>>>>> ea2d2368d7e20710b63b76d77dacbcb78f600d30
        }

        public string GetLocation()
        {
			 
          return Location;	
        }
		
	
		public bool IsTriggered() {
				 
				 return this.IsTriggeredDefault();
			 }

        public string GetSensorType()
        {
              return this.GetType().ToString();
        }

        public void UseBattery()
        {		 
				
               BatteryPercentage-=SINGLE_USAGE_DECREMENT; 
        }
    }

    public class MotionSensor : ICableSensor
    {public double TRIGGER  { get;   }	
	public string Location { get; set; }
 
        public MotionSensor(ILocationProvider provider)
        {
            TRIGGER = 20;
			Location=provider.Location;
        }

        public string GetLocation()
        {
            return Location;
        }

        public string GetSensorType()
        {
               return this.GetType().ToString();
        }
		
		
			 public bool IsTriggered() {
				 
				 return this.IsTriggeredDefault();
			 }

    }
	
		 static class ISensorHelper
	{
		
		public static bool IsTriggeredDefault(this ISensor iSensor)
		{
				Random rand = new Random();
				int numberUnder100 = rand.Next(100);
				if (numberUnder100 < iSensor.TRIGGER)
					return true; 
				return false;
		 }
		 
		 
	}
	
	

}
