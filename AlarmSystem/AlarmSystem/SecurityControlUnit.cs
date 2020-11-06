
using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    public class SecurityControlUnit<T> : ControlUnit<ICableSensor>, ISecurityControlUnit<ICableSensor> where T : ICableSensor
    {
        public override string PollSensors()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            TimeSpan nowTrimmed = new TimeSpan(now.Hours, now.Minutes, now.Seconds);
            return PollSensors(nowTrimmed);

        }

        //overloading  
        public string PollSensors(TimeSpan timeIsNow)
        {
            string output = "";
            TimeSpan now = timeIsNow;
            TimeSpan FROM = new TimeSpan(22, 0, 0);
            TimeSpan UNTIL = new TimeSpan(06, 0, 0);

            if ((now > FROM) || (now < FROM && now <= UNTIL))
            {
                output += base.PollSensors();
            }
            else
            {

                output += "Oh oh, I roam the city at night";
            }

            return output;
        }

        public SecurityControlUnit(List<ICableSensor> sensors) : base(sensors)
        {

        }


    }
}
