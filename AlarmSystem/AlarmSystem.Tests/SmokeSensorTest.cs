using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;


namespace AlarmSystem.Tests
{
    [TestClass]
    public class SmokeSensorTest
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private static IContainer Container { get; set; }
        public ILocationProvider FrontDoor { get; set; }
        public IBatterySensor SmokeSensor { get; set; }

        public SmokeSensorTest()
        {

            var builder = new ContainerBuilder();
             builder.RegisterType<SensorAtFrontDoor>().As<ILocationProvider>();

            builder.RegisterType<SmokeSensor>().As<IBatterySensor>();
            Container = builder.Build();

            FrontDoor = Container.Resolve<ILocationProvider>();
            SmokeSensor = Container.Resolve<IBatterySensor>();
            Assert.AreEqual(SmokeSensor.Location, FrontDoor.Location);


        }


        [TestMethod]
        public void TestGetLocationReturnsNotNotNull()
        {

            Assert.AreEqual("the front door", SmokeSensor.GetLocation());

        }



        //[TestMethod]
        //public void TestThatBatteryPercentageDepletes20PercentAtEachPoll()
        //{
        //    SmokeSensor sensor = new SmokeSensor();
        //    double batteryPercentage = sensor.GetBatteryPercentage();
        //    Assert.AreEqual(-1.0, batteryPercentage);
        //}



        //[TestMethod]
        // public void TestThatIsTriggeredReturnsTrue20PercentOfTheTime()
        // {
        //     SmokeSensor sensor = new SmokeSensor();
        //     bool isTriggered = sensor.IsTriggered;
        //     Assert.AreEqual(false, isTriggered);
        // }





        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {

            Assert.AreEqual("AlarmSystem.SmokeSensor", SmokeSensor.GetSensorType());
        }


    }
}
