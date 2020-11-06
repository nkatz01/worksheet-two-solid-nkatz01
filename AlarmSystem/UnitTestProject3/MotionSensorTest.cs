using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;
using AlarmSystem;

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


            builder.RegisterType<MotionSensor>().As<ICableSensor>();
            Container = builder.Build();

            LobbyProv = Container.Resolve<ILocationProvider>();
            MotionSensor = Container.Resolve<ICableSensor>();
            Assert.AreEqual(MotionSensor.Location, LobbyProv.Location);


        }


        [TestMethod]
        public void TestGetLocation()
        {

            Assert.AreEqual("the Lobby 1st floor", MotionSensor.GetLocation());

        }



        [TestMethod]
        public void TestThatIsTriggeredReturnsTrue20PercentOfTheTime()
        {
            double count = 0;

            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {

                    if (MotionSensor.IsTriggered())
                    {
                        count++;

                    };
                }
            }

            Assert.IsTrue((count / 100) < 21 && (count / 100) > 19);
        }




        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {

            Assert.AreEqual("AlarmSystem.MotionSensor", MotionSensor.GetSensorType());
        }


    }
}
