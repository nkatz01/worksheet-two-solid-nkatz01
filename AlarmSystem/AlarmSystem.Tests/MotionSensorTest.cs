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

            Assert.AreEqual("the Lobby 1st floor", MotionSensor.GetLocation());

        }



       [TestMethod]
         public void TestThatIsTriggeredReturnsTrue20PercentOfTheTime()
         {
            double outercount = 0;
            double innercount= 0;
            bool isTriggered =false;

            for (int j = 0; j < 100; j++)
            {innercount=0;
                for (int i = 0; i < 100; i++)
                {
                    isTriggered = MotionSensor.IsTriggered();
                    if (isTriggered){
                        innercount++;
					isTriggered=false;};
                }
              //	TestContext.WriteLine(innercount.ToString());   
                outercount+=innercount;
            }
			//TestContext.WriteLine(outercount.ToString());
			//TestContext.WriteLine((outercount/100).ToString());
            Assert.IsTrue((outercount/100)<21 && (outercount/100)>19 );
         }

       


        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {

            Assert.AreEqual("AlarmSystem.MotionSensor", MotionSensor.GetSensorType());
        }


    }
}
