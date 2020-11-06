using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;
using AlarmSystem;


namespace AlarmSystem.Tests
{
    [TestClass]
    public class SmokeSensorTest
    {



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



        [TestMethod]
        public void TestThatBatteryPercentageIs100PercentAtSensorCreation()
        {

            double batteryPercentage = SmokeSensor.BatteryPercentage;
            Assert.AreEqual(1.00, batteryPercentage);
        }




        [TestMethod]
        public void TestThatIsTriggeredReturnsTrue10PercentOfTheTime()
        {
            double count = 0;      

            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {

                    if (SmokeSensor.IsTriggered())
                    {
                        count++;
                        
                    };
                }
            }
            Assert.IsTrue((count / 100) < 11 && (count / 100) > 9);
        }






        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {

            Assert.AreEqual("AlarmSystem.SmokeSensor", SmokeSensor.GetSensorType());
        }


    }
}
