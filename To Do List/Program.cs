// See https://aka.ms/new-console-template for more information


Console.WriteLine("Welcome to the to-do list program.");
List<(string task, DateTime dueDate)> list = new List<(string, DateTime)>();
string option = "";

while (option != "done")
{
    Console.WriteLine("*************************" +
        "\n" +"What would you like to do?"
    + "\n" + "Enter 1 to add a task to the list."
    + "\n" + "Enter 2 to remove a task from the list."
    + "\n" + "Enter 3 to view the list."
    + "\n" + "Enter (done) to exit the program.");

    option = Console.ReadLine();

    if (option == "1")
    {
        Console.WriteLine("Please enter the name of the task to add to the list.");
        string task = Console.ReadLine();
        Console.WriteLine("Enter the due date for the task (yyyy-mm-dd):");
        DateTime dueDate;
        while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            Console.WriteLine("Invalid date format. Please enter the due date for the task (yyyy-mm-dd):");
        }
        list.Add((task, dueDate));
        Console.WriteLine("Task added to the list.");
    }
    else if (option == "2")
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i}: {list[i].task} (Due: {list[i].dueDate:yyyy-MM-dd})");
        }
        Console.WriteLine("Please enter the number of the task to remove from the list.");
        int taskNo;
        while (!int.TryParse(Console.ReadLine(), out taskNo) || taskNo < 0 || taskNo >= list.Count)
        {
            Console.WriteLine("Invalid task number. Please enter a valid task number to remove from the list.");
        }
        list.RemoveAt(taskNo);
        Console.WriteLine("Task removed from the list.");
    }
    else if (option == "3")
    {
        Console.WriteLine("Current tasks in the list:");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i}: {list[i].task} (Due: {list[i].dueDate:yyyy-MM-dd})");
            if (DateTime.Now > list[i].dueDate)
            {
                Console.WriteLine("WARNING: This task is past its due date!");
            }
        }
    }
    else if (option == "done")
    {
        Console.WriteLine("Exiting program.");
    }
    else
    {
        Console.WriteLine("Invalid option, please try again.");
    }
}

Console.WriteLine("Thank you for using the program.");
    
