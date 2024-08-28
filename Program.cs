using System;
using System.Globalization;

namespace Homework_31
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "tasks.json";
            TaskManager taskManager = new TaskManager(filePath);
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Отобразить все задачи");
                Console.WriteLine("2. Добавить новую задачу");
                Console.WriteLine("3. Изменить описание задачи");
                Console.WriteLine("4. Изменить статус задачи");
                Console.WriteLine("5. Удалить задачу");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите опцию: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        taskManager.DisplayTasks();
                        break;

                    case "2":
                        AddTask(taskManager);
                        break;

                    case "3":
                        ModifyTask(taskManager);
                        break;


                    case "4":
                        ChangeTaskStatus(taskManager);
                        break;

                    case "5":
                        DeleteTask(taskManager);
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Неверная опция, попробуйте снова.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        private static void AddTask(TaskManager taskManager)
        {
            try
            {
                Console.Write("Введите название задачи: ");
                string title = Console.ReadLine();

                Console.Write("Введите описание задачи: ");
                string description = Console.ReadLine();

                Console.Write("Введите дату завершения (дд.мм.гггг): ");
                DateTime dueDate;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate))
                {
                    Console.Write("Неверный формат даты. Введите дату завершения (дд.мм.гггг): ");
                }

                Console.Write("Введите приоритет задачи (Low (Низкий), Medium (Средний), High (Высокий)): ");
                Priority priority;
                while (!Enum.TryParse(Console.ReadLine(), true, out priority))
                {
                    Console.Write("Неверный приоритет. Введите приоритет задачи (Низкий, Средний, Высокий): ");
                }

                taskManager.AddTask(title, description, dueDate, priority);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении задачи: {ex.Message}");
            }
        }

        private static void ModifyTask(TaskManager taskManager)
        {
            try
            {
                taskManager.DisplayTasks();
                Console.Write("Введите индекс задачи для изменения: ");
                int index = int.Parse(Console.ReadLine());

                Console.Write("Введите новое описание: ");
                string newDescription = Console.ReadLine();

                taskManager.ModifyTask(index, newDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при изменении задачи: {ex.Message}");
            }
        }

        private static void ChangeTaskStatus(TaskManager taskManager)
        {
            try
            {
                Console.Write("Введите индекс задачи для изменения статуса: ");
                int index = int.Parse(Console.ReadLine());

                Console.Write("Введите новый статус (New, InProgress, Done): ");
                TaskStatus newStatus;
                while (!Enum.TryParse(Console.ReadLine(), true, out newStatus))
                {
                    Console.Write("Неверный статус. Введите новый статус (New, InProgress, Done): ");
                }

                taskManager.ChangeTaskStatus(index, newStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при изменении статуса задачи: {ex.Message}");
            }
        }

        private static void DeleteTask(TaskManager taskManager)
        {
            try
            {
                Console.Write("Введите индекс задачи для удаления: ");
                int index = int.Parse(Console.ReadLine());

                taskManager.DeleteTask(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении задачи: {ex.Message}");
            }
        }
    }
}