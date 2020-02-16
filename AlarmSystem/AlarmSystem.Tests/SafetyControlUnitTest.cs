using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;
using System.Collections.Generic;
namespace AlarmSystem.Tests
{
	[TestClass]
  public  class SafetyControlUnitTest
	//<T> : ControlUnit<T> where T : IBatterySensor
    {
	
		public SafetyControlUnit<IBatterySensor> SFCU_FS { get; set; }
		public SafetyControlUnit<IBatterySensor> SFCU_SS { get; set; }
 


		[TestMethod]
		 public  void TestThatPollFireSensorsSucceeds()
		{
			 ILocationProvider LFF = new SensorLobby1stFloor();
				IBatterySensor	 FS = new FireSensor(LFF);
			 SFCU_FS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor>{FS});
			  Assert.IsTrue((SFCU_FS.PollSensors() == "Polled AlarmSystem.FireSensor at the Lobby 1st floor successfully\n" || SFCU_FS.PollSensors() == "A AlarmSystem.FireSensor sensor was triggered at the Lobby 1st floor\n" )?true:false,"TestThatPollFireSensorsSucceeds() FAILED") ; 
			  
			  
		}
		
		[TestMethod]
		public  void TestThatPollSmokeSensorSucceeds()
		{
			 	ILocationProvider SAU = new SensorInAuditorium();
				IBatterySensor	 SS = new SmokeSensor(SAU);
				SFCU_SS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor>{SS});
			 Assert.IsTrue((SFCU_SS.PollSensors() == "Polled AlarmSystem.SmokeSensor at the auditorium successfully\n" || SFCU_SS.PollSensors() == "A AlarmSystem.SmokeSensor sensor was triggered at the auditorium\n" )?true:false,"TestThatPollSmokeSensorSucceeds() FAILED") ; 
			//Assert.AreEqual("A AlarmSystem.SmokeSensor sensor was triggered at the auditorium\n",SFCU_SS.PollSensors());
			// Assert.AreEqual("Polled AlarmSystem.SmokeSensor at the auditorium successfully\n",SFCU_SS.PollSensors());
			
			}

	[TestMethod]
	public void TestThatBatteryPercentageDepletes10PercentAtEachPollForFireSensor()
	{
		ILocationProvider		 LFF = new SensorLobby1stFloor();
		IBatterySensor	 FS = new FireSensor(LFF);
		SFCU_FS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor>{FS});
		
		SFCU_FS.PollSensors();
		Assert.AreEqual("Battery power of the Sensor at the Lobby 1st floor of type AlarmSystem.FireSensor is at 0.9percent\n",SFCU_FS.GetBatteryPercentage());
		 
	}
	
	[TestMethod]
	public void TestThatBatteryPercentageDepletes20PercentAtEachPollForSmokeSensor()
	{ 	
	 ILocationProvider	SAU = new SensorInAuditorium();
		IBatterySensor	SS = new SmokeSensor(SAU);
		SFCU_SS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor>{SS});

		SFCU_SS.PollSensors();
		Assert.AreEqual("Battery power of the Sensor at the auditorium of type AlarmSystem.SmokeSensor is at 0.8percent\n",SFCU_SS.GetBatteryPercentage());
		 
	}
	

 


       




    }
}
