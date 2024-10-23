
public abstract class Project                           
{ 
    public string Title { get; set; }                  //поля + властивості
    public int EstimatedHours { get; set; }

    public Project()                                   //конструктор за замовчуванням
    {
    }

    public Project(string title, int estimatedHours)   //базового класу
    {
        Title = title;
        EstimatedHours = estimatedHours;
    }

    public abstract void DisplayInfo();                //метод для виводу інфи
}
public interface ITaskable                             
{
    void AddTask(string task);                         //метод що додає завдання у проєкт 
}

public interface ICalculable                           
{
    decimal CalculateCost(decimal rate);               //метод для обчислення вартості проєкту на основі ставки 
}