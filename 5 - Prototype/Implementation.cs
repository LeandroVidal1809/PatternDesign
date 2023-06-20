using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5___Prototype
{
    /// <summary>
    /// Specify the kinds of  objects to create using a prototypical instance, and create new objects by copyng this prototype
    /// </summary>
    public abstract class Person
    {
        public abstract string Name { get; set; }
        public abstract Person Clone();

    }

    public class Manager : Person
    {
        public override string Name { get; set; }
        public Manager(string _name) 
        {
            Name = _name;
        }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public override string Name { get; set; }
        public Manager Manager { get; set; }
        public Employee(string _name,Manager manager)
        {
            Name = _name;
            Manager = manager;
        }
        public override Person Clone()
        {

            return (Person)MemberwiseClone();

        }
    }
}
