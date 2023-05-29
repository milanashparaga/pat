namespace Shparaga;

public abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public virtual void Add(Component component)
    {
    }

    public virtual void Remove(Component component)
    {
    }

    public virtual void Print()
    {
        Console.WriteLine(name);
    }
}

public class Chief : Component
{
    private List<Component> components = new List<Component>();

    public Chief(string name)
        : base(name)
    {
    }

    public override void Add(Component component)
    {
        components.Add(component);
    }

    public override void Remove(Component component)
    {
        components.Remove(component);
    }

    public override void Print()
    {
        Console.WriteLine("Имя шефа: " + name);
        Console.WriteLine("Подчинённые:");
        for (int i = 0; i < components.Count; i++)
        {
            components[i].Print();
        }
    }
}

public class Worker : Component
{
    public Worker(string name)
        : base(name)
    {
    }
}