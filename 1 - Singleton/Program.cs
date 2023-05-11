using Singleton;
using System.Security.Claims;

//Singleton:
//-Creational Pattern
//- Ensure that an class only has one instance and to provide global access to it 
//- Example : Logger
//- Class must be private or protect and contain and property (static) that
//  return the instance for ensure only one instance.

Console.Title = "Singleton Pattern";
var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if(instance1 == instance2 && instance2 == Logger.Instance)
{
    Console.WriteLine("Instances are the same");
}

instance1.Log("Logging instance 1");
instance2.Log("Logging instance 2");
Logger.Instance.Log("Logging instance");

Console.ReadLine();