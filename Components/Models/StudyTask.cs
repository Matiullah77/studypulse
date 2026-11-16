
namespace StudyPulse.Models;

public class StudyTask
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = "";

    public string Subject { get; set; } = "";

    public string Description { get; set; } = "";

    public DateTime Deadline { get; set; } = DateTime.Today;

    public string Priority { get; set; } = "Medium";

    public int EstimatedMinutes { get; set; } = 60;

    public bool IsCompleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
