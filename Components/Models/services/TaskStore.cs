
using System.Text.Json;
using StudyPulse.Models;

namespace StudyPulse.Services;

public class TaskStore
{
    private readonly string _filePath;
    private readonly object _lock = new();

    public TaskStore(IWebHostEnvironment environment)
    {
        string folder = Path.Combine(
            environment.ContentRootPath,
            "App_Data");

        Directory.CreateDirectory(folder);

        _filePath = Path.Combine(folder, "assignments.json");
    }

    public List<StudyTask> GetAll()
    {
        lock (_lock)
        {
            if (!File.Exists(_filePath))
                return new List<StudyTask>();

            string json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<StudyTask>>(json)
                   ?? new List<StudyTask>();
        }
    }

    public void Add(StudyTask task)
    {
        lock (_lock)
        {
            var tasks = GetAll();
            tasks.Add(task);
            Save(tasks);
        }
    }

    public void Update(StudyTask updatedTask)
    {
        lock (_lock)
        {
            var tasks = GetAll();

            int index = tasks.FindIndex(
                t => t.Id == updatedTask.Id);

            if (index < 0)
                return;

            tasks[index] = updatedTask;
            Save(tasks);
        }
    }

    public void Delete(Guid id)
    {
        lock (_lock)
        {
            var tasks = GetAll();
            tasks.RemoveAll(t => t.Id == id);
            Save(tasks);
        }
    }

    private void Save(List<StudyTask> tasks)
    {
        string json = JsonSerializer.Serialize(
            tasks,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(_filePath, json);
    }
}
