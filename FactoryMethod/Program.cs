// See https://aka.ms/new-console-template for more information
using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DiscountFactory>()
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("AR")
};

foreach (var fact in factories)
{
    var discountService = fact.CreateDiscountService();
    Console.WriteLine($"Percentage is {discountService.DiscountPercentage}");
}

Console.WriteLine();
