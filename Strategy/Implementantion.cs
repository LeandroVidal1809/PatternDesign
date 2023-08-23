using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    /// <summary>
    /// Strategy
    /// </summary>
     public interface IExportService
    {
        void Export(Order order);
    }

    public class Order
    {
        public string Customer { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }

        public IExportService? ExportService { get; set; }

        public Order(string customer, string name, int amount)
        {
            Customer = customer;
            Name = name;
            Amount = amount;
        }

        public void Export() 
        {
            ExportService?.Export(this);
        }
    }

    /// <summary>
    /// Concrete Strategy
    /// </summary>
    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to Json");
        }
    }

    /// <summary>
    /// Concrete Strategy
    /// </summary>
    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML");
        }
    }


    /// <summary>
    /// Concrete Strategy
    /// </summary>
    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV");
        }
    }





}
