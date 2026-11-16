
using StudyPulse.Models;

namespace StudyPulse.Services;

public static class PlannerEngine
{
    

    
    public static double CompletionPercentage(
        IEnumerable<StudyTask> tasks)
    {
        var list = tasks.ToList();

        if (list.Count == 0)
            return 0;

        int completed = list.Count(t => t.IsCompleted);

        return Math.Round(
            (double)completed / list.Count * 100, 1);
    }

    
    public static bool IsOverdue(
        StudyTask task,
        DateTime today)
    {
        return !task.IsCompleted &&
               task.Deadline.Date < today.Date;
    }

    
    public static bool IsOverdue(StudyTask task)
    {
        return IsOverdue(task, DateTime.Today);
    }

    
    public static bool IsDueSoon(
        StudyTask task,
        DateTime today)
    {
        return !task.IsCompleted &&
               task.Deadline.Date >= today.Date &&
               task.Deadline.Date <= today.Date.AddDays(3);
    }

   
    public static bool IsDueSoon(StudyTask task)
    {
        return IsDueSoon(task, DateTime.Today);
    }

  
    public static int PriorityValue(string priority)
    {
        return priority switch
        {
            "High" => 3,
            "Medium" => 2,
            "Low" => 1,
            _ => 0
        };
    }


   
    public static Func<T, TResult> Compose<T, TMiddle, TResult>(
        Func<T, TMiddle> first,
        Func<TMiddle, TResult> second)
    {
        return input => second(first(input));
    }

  
    public static TResult Pipe<T, TResult>(
        T value,
        Func<T, TResult> function)
    {
        return function(value);
    }

   
    public static double MinutesToHours(int minutes)
    {
        Func<int, double> convert =
            value => value / 60.0;

        Func<double, double> round =
            value => Math.Round(value, 1);

        var pipeline = Compose(convert, round);

        return Pipe(minutes, pipeline);
    }

   

    public static double UrgencyScore(
        StudyTask task,
        DateTime today)
    {
        int daysLeft =
            (task.Deadline.Date - today.Date).Days;

        double deadlineScore = daysLeft switch
        {
            < 0 => 100,
            0 => 90,
            1 => 80,
            2 => 70,
            3 => 60,
            <= 7 => 40,
            _ => 10
        };

        double priorityScore =
            PriorityValue(task.Priority) * 15;

        double workloadScore =
            Math.Min(
                Math.Max(0, task.EstimatedMinutes) / 60.0,
                10);

        return deadlineScore +
               priorityScore +
               workloadScore;
    }

       public static double UrgencyScore(StudyTask task)
    {
        return UrgencyScore(task, DateTime.Today);
    }

   

       public static IEnumerable<StudyTask> FilterTasks(
        IEnumerable<StudyTask> tasks,
        Func<StudyTask, bool> predicate)
    {
        return tasks.Where(predicate).ToList();
    }

   
    public static IEnumerable<TResult> MapTasks<TResult>(
        IEnumerable<StudyTask> tasks,
        Func<StudyTask, TResult> selector)
    {
        return tasks.Select(selector).ToList();
    }

    

  
    public static StudyTask WithCompletion(
        StudyTask original,
        bool completed)
    {
        return new StudyTask
        {
            Id = original.Id,
            Title = original.Title,
            Subject = original.Subject,
            Description = original.Description,
            Deadline = original.Deadline,
            Priority = original.Priority,
            EstimatedMinutes = original.EstimatedMinutes,
            IsCompleted = completed,
            CreatedAt = original.CreatedAt
        };
    }


    
    public static List<StudyTask> RecommendTasks(
        IEnumerable<StudyTask> tasks,
        DateTime today)
    {
        return FilterTasks(
                tasks,
                task => !task.IsCompleted)
            .OrderByDescending(
                task => UrgencyScore(task, today))
            .ThenBy(task => task.Deadline)
            .ToList();
    }

   
    public static List<StudyTask> RecommendTasks(
        IEnumerable<StudyTask> tasks)
    {
        return RecommendTasks(tasks, DateTime.Today);
    }

    public static double RemainingStudyHours(
        IEnumerable<StudyTask> tasks)
    {
        int minutes = FilterTasks(
                tasks,
                task => !task.IsCompleted)
            .Sum(task => Math.Max(0, task.EstimatedMinutes));

        return MinutesToHours(minutes);
    }


    public static int HighPriorityCount(
        IEnumerable<StudyTask> tasks)
    {
        return tasks.Count(task =>
            !task.IsCompleted &&
            task.Priority == "High");
    }


    
    public static TResult AggregateTasks<TResult>(
        IEnumerable<StudyTask> tasks,
        TResult seed,
        Func<TResult, StudyTask, TResult> reducer)
    {
        return tasks.Aggregate(seed, reducer);
    }

       public static int CountCompleted(
        IEnumerable<StudyTask> tasks)
    {
        return AggregateTasks(
            tasks,
            0,
            (count, task) =>
                count + (task.IsCompleted ? 1 : 0));
    }
}
