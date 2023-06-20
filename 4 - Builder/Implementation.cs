using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _4___Builder
{
    //    The intent of the builder pattern is to separate the construiction of a complex
    //object from its representation.By doing so, the same contruction
    //process can create different representations
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;   
        public Car(string carType)
        {
            _carType= carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb =  new StringBuilder();
            foreach (var part in _parts) 
            {
                sb.Append($"Car of type {_carType} has part {part}");
            }

            return sb.ToString();
        }

    }
    
    public abstract class CarBuilder
    {
        public Car Car { get; set; }
        public CarBuilder(string carType) 
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();

    }

    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder() 
        : base("Mini")
        {

        }

        public override void BuildEngine()
        {
            Car.AddPart("not a V8");
        }

        public override void BuildFrame()
        {
            Car.AddPart("3-door with stripes");
        }
    }
    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder()
        : base("BMW")
        {

        }

        public override void BuildEngine()
        {
            Car.AddPart("a fancy V8 Engine");
        }

        public override void BuildFrame()
        {
            Car.AddPart("5-door with metallic finish");
        }
    }

    public class Garage
    {
        private CarBuilder? _builder;
        public Garage()
        {

        }
        public void Construct(CarBuilder builder)
        {
            _builder = builder;
            _builder.BuildEngine();
            _builder.BuildFrame();
        }
    }
}
