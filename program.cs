using System;
using System.Collections.Generic;

public class Program

{    public static void Main(string[] args)
    {
        List<Project> projects = new List<Project>();

        while (true)
        {
            Console.WriteLine("1 додати новий проєкт");
            Console.WriteLine("2 вивести список проєктів");
            Console.WriteLine("3 вивести детальну інформацію про проєкт за його номером");
            Console.WriteLine("4 додати завдання до проєкту");
            Console.WriteLine("5 обчислити вартість проєкту");
            Console.WriteLine("6 зберегти проєкти у файл");
            Console.WriteLine("7 завантажити проєкти з файлу");
            Console.WriteLine("8 вихід");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 8)
            {
                Console.WriteLine("будь ласка, введіть ЧИСЛО від 1 до 8.");
            }

            switch (choice)
            {
                case 1:
                    AddNewProject(projects);
                    break;
                case 2:
                    DisplayProjects(projects);
                    break;
                case 3:
                    ShowProjectDetails(projects);
                    break;
                case 4:
                    AddTaskToProject(projects);
                    break;
                case 5:
                    CalculateProjectCost(projects);
                    break;
                case 6:
                    ProjectSerializer.SaveProjects(projects, "C:\\Users\\User\\Desktop\\о\\ooп\\lab5\\lab5\\XMLFile1.xml");
                    break;
                case 7:
                    projects = ProjectSerializer.LoadProjects("C:\\Users\\User\\Desktop\\о\\ooп\\lab5\\lab5\\XMLFile1.xml");
                    foreach (var project in projects)
                    {
                        Console.WriteLine($"{project}\n {project.Title}\n {project.EstimatedHours}\n");
                    }
                    break;
                case 8:
                    return;
            }
        }
    }


    private static void AddNewProject(List<Project> projects)                       //додавання проєкту
    {
        int type;
        while (true)
        {
            Console.WriteLine("оберіть, будь ласка, тип проєкту: 1 - Веб, 2 - Мобільний (натисніть n для повернення до головного меню)");
            string input = Console.ReadLine();
            if (input == "n")
            { 
                return;
            }
            if (int.TryParse(input, out type) && (type == 1 || type == 2))
            {
                break;
            }

            Console.WriteLine("будь ласка, введіть 1 для Веб або 2 для Мобільного проєкту");
        }
        Console.WriteLine("введіть назву проєкту (натисніть n для повернення до головного меню):");
        string title = Console.ReadLine();
        if (title == "n")
        {
            return;
        }

        int hours;
        while (true)
        {
            Console.WriteLine("введіть кількість годин, необхідних для завершення проєкту (натисніть n для повернення до головного меню):");
            string hoursInput = Console.ReadLine();
            if (hoursInput == "n")
            { 
                return;
            }

            if (int.TryParse(hoursInput, out hours) && hours >= 0)
            {
                break;
            }

            Console.WriteLine("будь ласка, введіть коректне число для кількості годин для завершення проєкту");
        }
        if (type == 1)
        {
            projects.Add(new WebDevelopmentProject(title, hours));
        }
        else
        {
            projects.Add(new MobileDevelopmentProject(title, hours));
        }
    }


    private static void DisplayProjects(List<Project> projects)                      //список проєктів
    {
        if (projects.Count == 0)
        {
            Console.WriteLine("список проєктів порожній");
            return;
        }

        for (int i = 0; i < projects.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {projects[i].Title}\n");
        }
    }


    private static void ShowProjectDetails(List<Project> projects)                  //вивід проєктів за їх номерами
    {
        if (projects.Count == 0)
        {
            Console.WriteLine("проєктів немає");
            return;
        }

        Console.WriteLine("введіть номер проєкту (або натисніть n для повернення до головного меню):");
        string input;
        int index;

        while (true)
        {
            input = Console.ReadLine();
            if (input == "n")
            {
                return;
            }

            if (int.TryParse(input, out index) && index >= 1 && index <= projects.Count)
            {
                break;
            }

            Console.WriteLine("проєкт не знайдено. будь ласка, введіть коректний номер проєкту або натисніть n для повернення до меню.");
        }
        projects[index - 1].DisplayInfo();
    }


    private static void AddTaskToProject(List<Project> projects)                      // додавання завдання
    {
        while (true)  
        {
            Console.WriteLine("введіть номер проєкту (або n для повернення до меню):");
            int index;
            string input = Console.ReadLine();

            if (input == "n")
            {
                return; 
            }

            if (!int.TryParse(input, out index) || index < 1 || index > projects.Count)
            {
                Console.WriteLine("проєкт не знайдено. будь ласка, введіть коректний номер проекту або n для повернення до меню");
                continue;  
            }

            Console.WriteLine("введіть завдання:");
            string task = Console.ReadLine();
            ((ITaskable)projects[index - 1]).AddTask(task);
            break;  
        }
    }
    private static void CalculateProjectCost(List<Project> projects)                   //метод, обчислює вартість проєкту
    {
        while (true)  
        {
            Console.WriteLine("введіть номер проєкту (або n для повернення до меню):");
            int index;
            string input = Console.ReadLine();

            if (input == "n")
            {
                return;  
            }

            if (!int.TryParse(input, out index) || index < 1 || index > projects.Count)
            {
                Console.WriteLine("проєкт не знайдено. будь ласка, введіть коректний номер проєкту або n для повернення у меню");
                continue;  
            }

            Console.WriteLine("введіть тариф (вартість години):");
            decimal rate;
            while (!decimal.TryParse(Console.ReadLine(), out rate) || rate < 0)
            {
                Console.WriteLine("будь ласка, введіть невід'ємне число для тарифу");
            }

            decimal cost = ((ICalculable)projects[index - 1]).CalculateCost(rate);
            Console.WriteLine("вартість проєкту: {0}", cost);
            break; 
        }
    }
}