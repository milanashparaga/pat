namespace Shparaga;

class Program
{
    static void Main(string[] args)
    {
        // Создаём иерархию сотрудников в компании
        Component owner = new Chief("Владелец компании");

        Component warehouseManager = new Chief("Начальник склада");
        Component warehouseEmployee1 = new Worker("Работник склада1");
        Component warehouseEmployee2 = new Worker("Работник склада2");

        Component headOffice = new Chief("Начальник офиса");
        Component officeWorker = new Worker("Работник офиса");

        headOffice.Add(officeWorker);
        warehouseManager.Add(warehouseEmployee1);
        warehouseManager.Add(warehouseEmployee2);
        owner.Add(headOffice);
        owner.Add(warehouseManager);

        // Создаём компанию
        Company company = new Company(owner);

        // СБ начинает следить за компанией
        SecurityService securityService = new SecurityService();

        securityService.StartMonitoringCompany(company);

        company.PrintAllEmployees();

        // СБ прекращает следить за компанией
        securityService.SuspendMonitoringCompany();

        Console.WriteLine();
        company.PrintAllEmployees();

        Console.Read();
    }
}