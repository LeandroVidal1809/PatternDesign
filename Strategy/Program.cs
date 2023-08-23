using Strategy;

Console.Title="Strategy";


var order = new Order("Leandro Vidal",  "Test of Strategy",5);
order.ExportService = new CSVExportService();
order.Export();

order.ExportService = new JsonExportService();
order.Export();

//We can add ExportService in the constructor.

Console.ReadKey();

