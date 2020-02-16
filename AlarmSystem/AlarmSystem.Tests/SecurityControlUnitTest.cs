using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;
using System.Collections.Generic;

namespace AlarmSystem.Tests
{	
	[TestClass]
	public class SecurityControlUnitTest
	//<T> : ControlUnit<T> where T : ICableSensor
    {
		 
		
		SecurityControlUnit<ICableSensor> SCCU_MS { get; set; }
                                             
	 



		[TestMethod]
        public  void  TestThatPollingMotionSensorNotBetween2200To0600Fails()
        {
         // TimeSpan(23, 0, 0)//succeeds
		 // TimeSpan(01, 0, 0)//succeeds
		  //TimeSpan(21, 0, 0)
		  	ILocationProvider	 FD = new SensorAtFrontDoor();
			ICableSensor	  MS = new MotionSensor(FD);
			SCCU_MS = new SecurityControlUnit<ICableSensor>(new List<ICableSensor>{MS});
			Assert.IsTrue((SCCU_MS.PollSensors(new TimeSpan(23, 0, 0)) == "Polled AlarmSystem.MotionSensor at the front door successfully\n" || SCCU_MS.PollSensors(new TimeSpan(23, 0, 0)) == "A AlarmSystem.MotionSensor sensor was triggered at the front door\n")?true:false,"TestThatPollingMotionSensorNotBetween2200To0600Fails() FAILED"); 
			Assert.IsTrue((SCCU_MS.PollSensors(new TimeSpan(01, 0, 0)) == "Polled AlarmSystem.MotionSensor at the front door successfully\n" || SCCU_MS.PollSensors(new TimeSpan(23, 0, 0)) == "A AlarmSystem.MotionSensor sensor was triggered at the front door\n")?true:false,"TestThatPollingMotionSensorNotBetween2200To0600Fails() FAILED"); 
			Assert.AreEqual("Oh oh, I roam the city at night" , SCCU_MS.PollSensors(new TimeSpan(21, 0, 0)));
			
			 
        }

 

	
		[TestMethod]
        public void TestThatPollMotionSensorsSucceeds()
        {
           	ILocationProvider	 FD = new SensorAtFrontDoor();
			ICableSensor	  MS = new MotionSensor(FD);
			SCCU_MS = new SecurityControlUnit<ICableSensor>(new List<ICableSensor>{MS});
			Assert.IsTrue((SCCU_MS.PollSensors() == "Polled AlarmSystem.MotionSensor at the front door successfully\n" || SCCU_MS.PollSensors() == "A AlarmSystem.MotionSensor sensor was triggered at the front door\n" || SCCU_MS.PollSensors() == "Oh oh, I roam the city at night")?true:false,"TestThatPollMotionSensorsSucceeds() FAILED") ; 
        }



	}
    
}
