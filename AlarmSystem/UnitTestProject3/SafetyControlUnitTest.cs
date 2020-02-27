using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;
using System.Collections.Generic;
using AlarmSystem;
namespace AlarmSystem.Tests
{
    [TestClass]
    public class SafetyControlUnitTest

    {

        public SafetyControlUnit<IBatterySensor> SFCU_FS { get; set; }
        public SafetyControlUnit<IBatterySensor> SFCU_SS { get; set; }



        [TestMethod]
        public void TestThatPollFireSensorsSucceeds()
        {
            ILocationProvider LFF = new SensorLobby1stFloor();
            IBatterySensor FS = new FireSensor(LFF);
            SFCU_FS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor> { FS });
            string resultingMesssage = SFCU_FS.PollSensors();
            Assert.IsTrue((resultingMesssage == "Polled AlarmSystem.FireSensor at the Lobby 1st floor successfully\n" || resultingMesssage == "A AlarmSystem.FireSensor sensor was triggered at the Lobby 1st floor\n") ? true : false, "TestThatPollFireSensorsSucceeds() FAILED");


        }

        [TestMethod]
        public void TestThatPollSmokeSensorSucceeds()
        {
            ILocationProvider SAU = new SensorInAuditorium();
            IBatterySensor SS = new SmokeSensor(SAU);
            SFCU_SS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor> { SS });
            string resultingMesssage = SFCU_SS.PollSensors();
            Assert.IsTrue((resultingMesssage == "Polled AlarmSystem.SmokeSensor at the auditorium successfully\n" || resultingMesssage == "A AlarmSystem.SmokeSensor sensor was triggered at the auditorium\n") ? true : false, "TestThatPollSmokeSensorSucceeds() FAILED");


        }

        [TestMethod]
        public void TestThatBatteryPercentageDepletes10PercentAtEachPollForFireSensor()
        {
            ILocationProvider LFF = new SensorLobby1stFloor();
            IBatterySensor FS = new FireSensor(LFF);
            SFCU_FS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor> { FS });

            SFCU_FS.PollSensors();
            Assert.AreEqual("Battery power of the Sensor at the Lobby 1st floor of type AlarmSystem.FireSensor is at 0.9percent\n", SFCU_FS.GetBatteryPercentage());

        }

        [TestMethod]
        public void TestThatBatteryPercentageDepletes20PercentAtEachPollForSmokeSensor()
        {
            ILocationProvider SAU = new SensorInAuditorium();
            IBatterySensor SS = new SmokeSensor(SAU);
            SFCU_SS = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor> { SS });

            SFCU_SS.PollSensors();
            Assert.AreEqual("Battery power of the Sensor at the auditorium of type AlarmSystem.SmokeSensor is at 0.8percent\n", SFCU_SS.GetBatteryPercentage());

        }










    }
}
