using TaskManagement.Domain.Entities;
using TaskStatus = TaskManagement.Domain.Entities.TaskStatus;
using TaskPriority = TaskManagement.Domain.Entities.TaskPriority;

namespace TaskManagement.UnitTests.Domain;

public class TaskItemTests
{
    [Fact]
    public void Task_CanBeAssignedToUser()
    {
        var owner = new User("Alice", "alice@example.com", "hash");
        var project = new Project("Project", "Description", owner.Id);
        var task = new TaskItem("Task", "Description", project.Id);
        var assignee = new User("Bob", "bob@example.com", "hash");

        task.AssignTo(assignee.Id);

        Assert.Equal(assignee.Id, task.AssignedUserId);
    }

    [Fact]
    public void Task_DefaultStatusIsTodo()
    {
        var project = new Project("Project", "Description", Guid.NewGuid());
        var task = new TaskItem("Task", "Description", project.Id);

        Assert.Equal(TaskStatus.NotStarted, task.Status);
    }

    [Fact]
    public void Task_DefaultPriorityIsMedium()
    {
        var project = new Project("Project", "Description", Guid.NewGuid());
        var task = new TaskItem("Task", "Description", project.Id);

        Assert.Equal(TaskPriority.Medium, task.Priority);
    }
}
