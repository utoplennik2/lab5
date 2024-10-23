using System;
using System.Collections.Generic;

public class WebDevelopmentProject : Project, ITaskable, ICalculable      //дочірній клас ВЕБ містить інтерфейси ITaskable та ICalculable
{
    private List<string> tasks = new List<string>();

    public WebDevelopmentProject() : base()
    {
    }

    public WebDevelopmentProject(string title, int estimatedHours)            //конструктор класу WebDevelopmentProject для веб
        : base(title, estimatedHours)
    {
    }

    public void AddTask(string task)                                          //додає завдання для веб
    {
        tasks.Add(task);
    }

    public decimal CalculateCost(decimal rate)                                //вартість проєкту залежить від кількості годин для веб
    {
        return EstimatedHours * rate;
    }

    public override void DisplayInfo()                                        //виводить інфу
    {
        Console.WriteLine("проєкт веб-розробки: {0}, орієнтовні години: {1}", Title, EstimatedHours);
        Console.WriteLine("завдання:");
        foreach (var task in tasks)
        {
            Console.WriteLine("- {0} \n", task);
        }
    }
}