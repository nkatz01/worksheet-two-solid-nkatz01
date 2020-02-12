using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using Autofac;

namespace AlarmSystem.Tests
{
    [TestClass]
    public class FireSensorTest
    {
		 private TestContext testContextInstance;
		  public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
		
		 private static IContainer Container { get; set; }
		public ILocationProvider AuditorProv { get; set; }
		   public  IBatterySensor FireSensor { get; set; }
			
			public FireSensorTest()
			{
			
			var builder = new ContainerBuilder();
            builder.RegisterType<SensorInAuditorium>().As<ILocationProvider>();
            builder.RegisterType<FireSensor>().As<IBatterySensor>();
            Container = builder.Build();
			//UnitTest1 ut = new UnitTest1(); 
      
      
			 
				   
				 			
				  AuditorProv = Container.Resolve<ILocationProvider>();
				  FireSensor = Container.Resolve<IBatterySensor>();
            //   Trace.WriteLine("Trace Trace the World");
            //  Debug.WriteLine("Debug Debug WOrld");

            //lp1.MessageProvider = mp;
            //    mr.Render();

            //builder.RegisterType<SensorLobby1stFloor>().As<ILocationProvider>();
            //	builder.RegisterType<SensorAtFrontDoor>().As<ILocationProvider>();


        }
		
			
		[TestMethod]
		public void TestCreatedSensors(){


       Assert.AreEqual(true, 1 == 2, "Failed on the following test case: AB");

           // Assert.AreEqual(FireSensor.Location, AuditorProv.Location, "yooo");
            //   TestContext.WriteLine((FireSensor.Location== AuditorProv.Location).ToString());
            //Assert(FireSensor.Location == AuditorProv.Location, "true", "false");
        }
		
		
		
       /*  [TestMethod]
        public void TestThatIsTriggeredReturnsFalse()
        {
            FireSensor sensor = new FireSensor(new ILocationProvider());
            bool isTriggered = sensor.IsTriggered;
            Assert.AreEqual(false, isTriggered);
        }

        [TestMethod]
        public void TestThatGetLocationReturnsNull()
        {
            FireSensor sensor = new FireSensor();
            string location = sensor.GetLocation();
            Console.WriteLine(location);
            Assert.AreEqual(String.Empty, location);
        }

        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {
            FireSensor sensor = new FireSensor();
            string sensorType = sensor.GetSensorType();
            Assert.AreEqual(String.Empty, sensorType);
        }

        [TestMethod]
        public void TestThatGetBatteryPercentageReturnsNegativeOne()
        {
            FireSensor sensor = new FireSensor();
            double batteryPercentage = sensor.GetBatteryPercentage();
            Assert.AreEqual(-1.0, batteryPercentage);
        } */
    }
	
	 
}
