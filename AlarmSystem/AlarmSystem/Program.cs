﻿

using System.Collections.Generic;
using System;
using System.Reflection;
using Autofac;

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
               
                SafetyControlUnit<IBatterySensor> SafetyControlUnit = new SafetyControlUnit<IBatterySensor>(new List<IBatterySensor> { s1, s2 });
                SecurityControlUnit<ICableSensor> SecurityControlUnit = new SecurityControlUnit<ICableSensor>(new List<ICableSensor> { s3 });
             




               
			    string input ="exit";
			
		
                while (input.Equals("exit"))
                {
				
                    Console.WriteLine("Type \"poll\" to poll all sensors once or \"exit\" to exit"); 
                    input = Console.ReadLine();
                    if (input.Equals("poll"))
                    {
				
                       Console.WriteLine(SafetyControlUnit.PollSensors());  
						 Console.WriteLine(SafetyControlUnit.GetBatteryPercentage());
						 Console.WriteLine(SecurityControlUnit.PollSensors()); 
                     }
                }
 

               
 				 
				 
					
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error during configuration demonstration: {0}", ex);
            }

 
        }

    }
}
