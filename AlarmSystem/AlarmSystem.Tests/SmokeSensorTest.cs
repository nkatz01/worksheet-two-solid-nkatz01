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



        [TestMethod]
       public void TestThatBatteryPercentageIs100PercentAtSensorCreation() 
         {
              
            double batteryPercentage = SmokeSensor.BatteryPercentage;
             Assert.AreEqual(1.00, batteryPercentage);
       }


 
       [TestMethod]
         public void TestThatIsTriggeredReturnsTrue10PercentOfTheTime()
         {
            double outercount = 0;
            double innercount= 0;
            bool isTriggered =false;

            for (int j = 0; j < 100; j++)
            {innercount=0;
                for (int i = 0; i < 100; i++)
                {
                    isTriggered = SmokeSensor.IsTriggered();
                    if (isTriggered){
                        innercount++;
					isTriggered=false;};
                }
             // 	TestContext.WriteLine(innercount.ToString());   
                outercount+=innercount;
            }
			//TestContext.WriteLine(outercount.ToString());
			//TestContext.WriteLine((outercount/100).ToString());
            Assert.IsTrue((outercount/100)<11 && (outercount/100)>9 );
         } 






        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {

            Assert.AreEqual("AlarmSystem.SmokeSensor", SmokeSensor.GetSensorType());
        }


    }
}
