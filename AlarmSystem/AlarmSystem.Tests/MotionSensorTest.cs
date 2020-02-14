using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;

namespace AlarmSystem.Tests
{
    [TestClass]
    public class MotionSensorTest
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private static IContainer Container { get; set; }
        public ILocationProvider LobbyProv { get; set; }
        public ICableSensor MotionSensor { get; set; }

        public MotionSensorTest()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<SensorLobby1stFloor>().As<ILocationProvider>();
             //  builder.RegisterType<SensorAtFrontDoor>().As<ILocationProvider>();

            builder.RegisterType<MotionSensor>().As<ICableSensor>();
            Container = builder.Build();

            LobbyProv = Container.Resolve<ILocationProvider>();
            MotionSensor = Container.Resolve<ICableSensor>();
            Assert.AreEqual(MotionSensor.Location, LobbyProv.Location);


        }


        [TestMethod]
        public void TestGetLocation()
        {

            Assert.AreEqual("Lobby 1st floor", MotionSensor.GetLocation());

        }



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

            Assert.AreEqual("AlarmSystem.MotionSensor", MotionSensor.GetSensorType());
        }


    }
}
