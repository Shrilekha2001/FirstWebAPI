// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;

Console.WriteLine("API CLIENT");

//EmployeeAPIClient.AddEmployee().Wait();
//Console.ReadLine();
//int Id = 10;
//EmployeeAPIClient.UpdateEmployee(Id).Wait();
//Console.ReadLine();
Console.WriteLine("Deleting id  10");
int id = 10;
EmployeeAPIClient.DeleteEmployee(id).Wait();
Console.ReadLine();

