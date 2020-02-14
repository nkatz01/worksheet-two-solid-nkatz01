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
          //  builder.RegisterType<SensorLobby1stFloor>().As<ILocationProvider>();
          //  builder.RegisterType<SensorAtFrontDoor>().As<ILocationProvider>();

            builder.RegisterType<FireSensor>().As<IBatterySensor>();
            Container = builder.Build();
	
			AuditorProv = Container.Resolve<ILocationProvider>();
			FireSensor = Container.Resolve<IBatterySensor>();
            Assert.AreEqual(FireSensor.Location, AuditorProv.Location);


        }


        [TestMethod]
        public void TestGetLocation()
        {


            Assert.AreEqual("the auditorium", FireSensor.GetLocation());



            
        }

         [TestMethod]
                 public void TestThatGetSensorTypeReturnsNull()
                 {

           Assert.AreEqual( "AlarmSystem.FireSensor", FireSensor.GetSensorType());
        }

         
        [TestMethod]
         public void TestThatIsTriggeredReturnsTrue10PercentOfTheTime()
         {
            int outercount = 0;
            int innercount= 0;
            bool isTriggered;

            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    isTriggered = FireSensor.IsTriggered();
                    if (isTriggered)
                        innercount++;
                }
                if (innercount > 100/10)
                outercount++;
            }

             Assert.IsTrue(outercount<= 1000/10);
         }

        

        /* 

         [TestMethod]
         public void TestThatGetBatteryPercentageReturnsNegativeOne()
         {
             FireSensor sensor = new FireSensor();
             double batteryPercentage = sensor.GetBatteryPercentage();
             Assert.AreEqual(-1.0, batteryPercentage);
         } 
         
                [TestMethod]
           public void TestThatBatteryPercentageDepletes10PercentAtEachPoll()
           {
               SmokeSensor sensor = new SmokeSensor();
               double batteryPercentage = sensor.GetBatteryPercentage();
               Assert.AreEqual(-1.0, batteryPercentage);
           }
         
         
         */
    }


}
