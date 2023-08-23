using Mementor;
using static Mementor.EmployeeManagerRepository;

Console.Title = "Mementor";



CommandManager commandManager = new CommandManager();
IEmployeeManagerRepository repository = new EmployeeManagerRepository();


commandManager.Invoke(new AddEmployeeToMangaerList(repository, 1, new Employee(123, "Leandro1")));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToMangaerList(repository, 1, new Employee(234, "Leandro2")));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToMangaerList(repository, 2, new Employee(567, "Leandro3")));
repository.WriteDataStore();


Console.ReadKey();