using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon =  new OneEuroCoupon();
var twoEuroCoupon = new TwoEuroCoupon();

var meatBaseMenu = new MeatMenu(noCoupon);
Console.WriteLine($"Meat Base Menu,no coupon: {meatBaseMenu.CalculatePrice()} euro.");

meatBaseMenu = new MeatMenu(oneEuroCoupon);
Console.WriteLine($"Meat Base Menu,one euro coupon: {meatBaseMenu.CalculatePrice()} euro.");


var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian Base Menu,no coupon: {vegetarianMenu.CalculatePrice()} euro.");

vegetarianMenu = new VegetarianMenu(twoEuroCoupon);
Console.WriteLine($"Vegetarian Base Menu,two euro coupon: {vegetarianMenu.CalculatePrice()} euro.");

Console.ReadKey();

