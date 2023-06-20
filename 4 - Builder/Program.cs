using _4___Builder;

Console.Title = "Builder";
var garage =  new Garage();
var bmwbuilder =  new BMWBuilder();
var minibuilder =  new MiniBuilder();


garage.Construct(minibuilder);
Console.WriteLine(minibuilder.Car.ToString());

garage.Construct(bmwbuilder);
Console.WriteLine(bmwbuilder.Car.ToString());

Console.ReadLine();