﻿//#define ASK
#define DEVMOD
using System.Collections.Generic;
using System;
using System.Reflection;
using Autofac;
//dotnet run
namespace AlarmSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces();

            var container = builder.Build();
            try
            {
                using var scope = container.BeginLifetimeScope();
                var s1 = scope.Resolve<IBatterySensor>();				
                var s2 = scope.Resolve<IBatterySensor>();
                var s3 = scope.Resolve<ICableSensor>();
               // ControlUnit<ISensor> controlUnit = new ControlUnit<ISensor>(new List<ISensor> { s1, s2 });
                 SafetyControlUnit<IBatterySensor> SafetycontrolUnit = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor> { s1, s2 });
				
				 
				 //Console.WriteLine(  s1 is IBatterySensor ); 
				
                SecurityControlUnit<ICableSensor> securityControlUnit = new SecurityControlUnit<ICableSensor>(new List<ICableSensor> { s3 });
                // Console.WriteLine("all fine");




                #region
#if DEVMOD








#if ISOLATE && ASK
			    string input ="exit";
			
		
                while (input.Equals("exit"))
                {
				
                    Console.WriteLine("Type \"poll\" to poll all sensors once or \"exit\" to exit"); 
                    input = Console.ReadLine();
                    if (input.Equals("poll"))
                    {
				
                       SafetyControlUnit.PollSensors(); //uncomment
                     }
                }
#endif


                SafetycontrolUnit.PollSensors(); //remove
               securityControlUnit.PollSensors(); //remove
				 SafetycontrolUnit.GetBatteryPercentage();
				 
					
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error during configuration demonstration: {0}", ex);
            }

#endif
            #endregion
        }

    }
}
