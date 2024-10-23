using System;
using System.Collections.Generic;

public class MobileDevelopmentProject : Project, ITaskable, ICalculable   //дочірній клас моб містить інтерфейси ITaskable та ICalculable
{
    private List<string> tasks = new List<string>();
    public MobileDevelopmentProject() : base()
    {
    }
    public MobileDevelopmentProject(string title, int estimatedHours)             //конструктор класу WebDevelopmentProject для моб
        : base(title, estimatedHours)
    {
    }
    public void AddTask(string task)                                              //додає завдання для моб
    {
        tasks.Add(task);
    }

    public decimal CalculateCost(decimal rate)                                    //вартість проєкту залежить від кількості годин для моб
    {
        return EstimatedHours * rate;
    }

    public override void DisplayInfo()                                            //перевизначений метод
    {
        Console.WriteLine("проєкт мобільної розробки: {0}, орієнтовні години:{1}", Title, EstimatedHours);
        Console.WriteLine("завдання:");
        foreach (var task in tasks)
        {
            Console.WriteLine("- {0} \n", task);
        }
    }
}