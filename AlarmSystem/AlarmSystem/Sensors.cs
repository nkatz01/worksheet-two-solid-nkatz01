﻿using System;
 namespace AlarmSystem
{
    public class FireSensor : IBatterySensor
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
		        public bool IsTriggered() {
				
				Random rand = new Random();
				 int numberUnder100 = rand.Next(100);
				  if (numberUnder100 < TRIGGER)
					  return true; 
				  return false;
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
            TRIGGER = 10;
			Location=provider.Location;
			BatteryPercentage=1.00;
			SINGLE_USAGE_DECREMENT=0.20;
        }

        public string GetLocation()
        {
			 
          return Location;	
        }
		
		 public bool IsTriggered() {
				
				Random rand = new Random();
				 int numberUnder100 = rand.Next(100);
				  if (numberUnder100 < TRIGGER)
					  return true; 
				  return false;
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
				
				Random rand = new Random();
				 int numberUnder100 = rand.Next(100);
				  if (numberUnder100 < TRIGGER)
					  return true; 
				  return false;
			  }


    }
}
