using TaskManagement.Domain.Entities;

namespace TaskManagement.UnitTests.Domain;

public class ProjectTests
{
    [Fact]
    public void Project_HasOwner()
    {
        var owner = new User("Alice", "alice@example.com", "hash");
        var project = new Project("Project", "Description", owner.Id);

        Assert.Equal(owner.Id, project.OwnerId);
    }

    [Fact]
    public void Task_BelongsToProject()
    {
        var owner = new User("Alice", "alice@example.com", "hash");
        var project = new Project("Project", "Description", owner.Id);
        var task = new TaskItem("Task", "Description", project.Id);

        project.AddTask(task);

        Assert.Equal(project.Id, task.ProjectId);
        Assert.Contains(task, project.Tasks);
    }
}
