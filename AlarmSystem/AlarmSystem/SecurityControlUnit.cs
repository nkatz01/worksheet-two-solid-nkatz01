#define POLL
#define DEVMOD
using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    class SecurityControlUnit<T> : ControlUnit<T> where T : ICableSensor
    {
#if DEVMOD





        public override void PollSensors()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            TimeSpan nowTrimmed = new TimeSpan(now.Hours, now.Minutes, now.Seconds);
            TimeSpan FROM = new TimeSpan(22, 0, 0);
            TimeSpan UNTIL = new TimeSpan(06, 0, 0);
			
             if ((nowTrimmed > FROM) || (nowTrimmed < FROM && nowTrimmed <= UNTIL))
            {
                Console.WriteLine("Who's not asleep???");
				
                base.PollSensors();
            }
            else
            {
				
                Console.WriteLine("Oh oh, I roam the city at night");
            }
			
			 
        }

#endif



        public SecurityControlUnit(List<T> sensors) : base(sensors)
        {
            
        }




    }
}
