using TemplateMethod;

Console.Title = "Template Method";

ExchangeMailParser exchangeMailParser= new ExchangeMailParser();
Console.WriteLine(exchangeMailParser.ParseMailBody("aaa-bbb-ccc"));
Console.WriteLine();

ApacheMailParser apacheMailParser = new ApacheMailParser();
Console.WriteLine(exchangeMailParser.ParseMailBody("ddd-eee-fff"));
Console.WriteLine();



EudoraMailParser eudoraMailParser = new EudoraMailParser();
Console.WriteLine(eudoraMailParser.ParseMailBody("ggg-hhh-iii"));
Console.WriteLine();

Console.ReadKey();