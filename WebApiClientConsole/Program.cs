// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;

Console.WriteLine("API CLIENT");

EmployeeAPIClient.AddEmployee().Wait();
int Id = 10;
EmployeeAPIClient.UpdateEmployee(Id).Wait();
Console.ReadLine();

