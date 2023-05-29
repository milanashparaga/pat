namespace Shparaga;

public interface IObserver
{
    void Update();
}

public interface IObservable
{
    public void RegisterObserver(IObserver o);
    public void RemoveObserver(IObserver o);
    public void NotifyObservers();
}

public class Company : IObservable
{
    private readonly List<IObserver> _observers;
    private readonly Component _employees;

    public Company(Component employees)
    {
        _employees = employees;
        _observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver o)
    {
        _observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        _observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (IObserver o in _observers)
        {
            o.Update();
        }
    }

    public void PrintAllEmployees()
    {
        _employees.Print();
        NotifyObservers();
    }
}

public class SecurityService : IObserver
{
    private IObservable _company;

    public SecurityService()
    {
    }

    public SecurityService(IObservable obs)
    {
        _company = obs;
        _company.RegisterObserver(this);
    }


    public void Update()
    {
        Console.WriteLine("Поступил запрос на вывод списка всех сотрудников");
    }

    public void StartMonitoringCompany(IObservable obs)
    {
        SuspendMonitoringCompany();
        _company = obs;
        _company.RegisterObserver(this);
    }

    public void SuspendMonitoringCompany()
    {
        _company?.RemoveObserver(this);
        _company = null;
    }
}