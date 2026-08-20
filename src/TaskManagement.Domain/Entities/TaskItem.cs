namespace TaskManagement.Domain.Entities;

public class TaskItem : BaseEntity
{
    public TaskItem(
        string title,
        string description,
        Guid projectId,
        DateTime? dueDate = null,
        TaskPriority priority = TaskPriority.Medium)
    {
        Title = GuardTitle(title);
        Description = description ?? string.Empty;
        ProjectId = projectId;
        DueDate = dueDate;
        Priority = priority;
        Status = TaskStatus.NotStarted;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime? DueDate { get; private set; }

    public TaskStatus Status { get; private set; }

    public TaskPriority Priority { get; private set; }

    public Guid ProjectId { get; private set; }

    public Project? Project { get; private set; }

    public Guid? AssignedUserId { get; private set; }

    public User? AssignedUser { get; private set; }

    public void UpdateDetails(string title, string description, DateTime? dueDate)
    {
        Title = GuardTitle(title);
        Description = description ?? string.Empty;
        DueDate = dueDate;
        Touch();
    }

    public void SetStatus(TaskStatus status)
    {
        if (Status == status)
            return;

        Status = status;
        Touch();
    }

    public void SetPriority(TaskPriority priority)
    {
        if (Priority == priority)
            return;

        Priority = priority;
        Touch();
    }

    public void SetDueDate(DateTime? dueDate)
    {
        if (DueDate == dueDate)
            return;

        DueDate = dueDate;
        Touch();
    }

    public void AssignTo(Guid? userId)
    {
        if (AssignedUserId == userId)
            return;

        AssignedUserId = userId;
        AssignedUser = null;
        Touch();
    }

    internal void SetProject(Project? project)
    {
        Project = project;

        if (project is null)
            ProjectId = Guid.Empty;
    }

    private static string GuardTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Task title cannot be empty.", nameof(title));

        return title.Trim();
    }
}
