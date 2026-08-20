namespace TaskManagement.Domain.Entities;

public class Project : BaseEntity
{
    private readonly List<TaskItem> _tasks = new();

    public Project(string name, string description, Guid ownerId)
    {
        Name = GuardName(name);
        Description = description ?? string.Empty;
        OwnerId = ownerId;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public Guid OwnerId { get; private set; }

    public User? Owner { get; private set; }

    public IReadOnlyCollection<TaskItem> Tasks => _tasks;

    public void UpdateDetails(string name, string description)
    {
        Name = GuardName(name);
        Description = description ?? string.Empty;
        Touch();
    }

    public void AddTask(TaskItem task)
    {
        ArgumentNullException.ThrowIfNull(task);

        if (task.ProjectId != Id)
            throw new InvalidOperationException("The task does not belong to this project.");

        task.SetProject(this);
        _tasks.Add(task);
        Touch();
    }

    public void RemoveTask(TaskItem task)
    {
        ArgumentNullException.ThrowIfNull(task);

        if (_tasks.Remove(task))
        {
            task.SetProject(null);
            Touch();
        }
    }

    private static string GuardName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Project name cannot be empty.", nameof(name));

        return name.Trim();
    }
}
