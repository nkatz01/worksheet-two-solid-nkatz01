using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AlarmSystem;
namespace AlarmSystem.Tests
{
    [TestClass]
    public class SecurityControlUnitTest

    {


        SecurityControlUnit<ICableSensor> SCCU_MS { get; set; }





        [TestMethod]
        public void TestThatPollingMotionSensorNotBetween2200To0600Fails()
        {

            ILocationProvider FD = new SensorAtFrontDoor();
            ICableSensor MS = new MotionSensor(FD);
            SCCU_MS = new SecurityControlUnit<ICableSensor>(new List<ICableSensor> { MS });
            string resultingMessage = SCCU_MS.PollSensors(new TimeSpan(23, 0, 0));
            Assert.IsTrue((resultingMessage == "Polled AlarmSystem.MotionSensor at the front door successfully\n" || resultingMessage == "A AlarmSystem.MotionSensor sensor was triggered at the front door\n") ? true : false, "TestThatPollingMotionSensorNotBetween2200To0600Fails() FAILED");
            resultingMessage = SCCU_MS.PollSensors(new TimeSpan(01, 0, 0));
            Assert.IsTrue((resultingMessage == "Polled AlarmSystem.MotionSensor at the front door successfully\n" || resultingMessage == "A AlarmSystem.MotionSensor sensor was triggered at the front door\n") ? true : false, "TestThatPollingMotionSensorNotBetween2200To0600Fails() FAILED");
            Assert.AreEqual("Oh oh, I roam the city at night", SCCU_MS.PollSensors(new TimeSpan(21, 0, 0)));


        }




        [TestMethod]
        public void TestThatPollMotionSensorsSucceeds()
        {
            ILocationProvider FD = new SensorAtFrontDoor();
            ICableSensor MS = new MotionSensor(FD);
            SCCU_MS = new SecurityControlUnit<ICableSensor>(new List<ICableSensor> { MS });
            string resultingMesssage = SCCU_MS.PollSensors();
            Assert.IsTrue((resultingMesssage == "Polled AlarmSystem.MotionSensor at the front door successfully\n" || resultingMesssage == "A AlarmSystem.MotionSensor sensor was triggered at the front door\n" || resultingMesssage == "Oh oh, I roam the city at night") ? true : false, "TestThatPollMotionSensorsSucceeds() FAILED");
        }



    }

}
