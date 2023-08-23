using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public Employee(int id, string name) 
        {
            Id = id;
            Name = name;    
        }
    }

    public class Manager :  Employee
    {
        public List<Employee> Employees = new List<Employee>();
        public Manager(int id, string name)
            :base(id,name)
        {

        }

    }

    /// <summary>
    /// Receiver (Interface)
    /// </summary>
    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);    
        void RemoveEmploye(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteDataStore();
    }


    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new List<Manager>()
        {
            new Manager(1, "Leandro"),
            new Manager(2, "Test2")
        };



        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Add(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
           return  _managers.First(x => x.Id == managerId).Employees.Any(y => y.Id == employeeId);
        }

        public void RemoveEmploye(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Remove(employee);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id},{manager.Name}");
                if(manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id} , {employee.Name} ");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employees.");
                }

            }
        }

        public interface ICommand
        {
            void Execute();
            bool CanExecute();
        }

        public class AddEmployeeToMangaerList : ICommand
        {
            private readonly IEmployeeManagerRepository _employeeManagerRepository;
            private readonly int _managerId;
            private readonly Employee? _employee;

            public AddEmployeeToMangaerList(IEmployeeManagerRepository employeeManagerRepository, int managerId,Employee? employee)
            {
                _employeeManagerRepository = employeeManagerRepository;
                _managerId = managerId;
                _employee = employee;
            }

            public bool CanExecute()
            {
                if(_employee == null)
                {
                    return false;
                }

                if (_employeeManagerRepository.HasEmployee(_managerId, _employee.Id)) 
                {
                    return false;
                }

                return true;
            }

            public void Execute()
            {
                if(_employee == null)
                {
                    return;
                }
                _employeeManagerRepository.AddEmployee(_managerId, _employee);
            }
        }

        public class CommandManager
        {
            public void Invoke(ICommand command)
            {
                if (command.CanExecute())
                {
                    command.Execute();
                }
            }
        }


    }
}
