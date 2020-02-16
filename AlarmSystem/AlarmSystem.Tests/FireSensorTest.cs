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
            double outercount = 0;
            double innercount= 0;
            bool isTriggered =false;

            for (int j = 0; j < 100; j++)
            {innercount=0;
                for (int i = 0; i < 100; i++)
                {
                    isTriggered = FireSensor.IsTriggered();
                    if (isTriggered){
                        innercount++;
					isTriggered=false;};
                }
                 outercount+=innercount;
            }
			 
            Assert.IsTrue((outercount/100)<6 && (outercount/100)>4 );
         }

        

       

          [TestMethod]
       public void TestThatBatteryPercentageIs100PercentAtSensorCreation() 
         {
              
            double batteryPercentage = FireSensor.BatteryPercentage;
             Assert.AreEqual(1.00, batteryPercentage);
       }
           
    }


}
