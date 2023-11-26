using System;
using System.Collections.Generic;

public class Client
{
    public int Id { get; }
    public string Name { get; set; }
    public string ServiceType { get; set; }

    public Client(int id)
    {
        Id = id;
    }
}

public class Bank
{
    private Queue<Client> clientQueue = new Queue<Client>();

    public void EnqueueClient(string name, string serviceType)
    {
        Client newClient = new Client(clientQueue.Count + 1)
        {
            Name = name,
            ServiceType = serviceType
        };

        clientQueue.Enqueue(newClient);

        Console.WriteLine($"Клиент {newClient.Name} добавлен в очередь для {newClient.ServiceType}.");
        DisplayQueueStatus();
    }

    public void ServeNextClient()
    {
        if (clientQueue.Count > 0)
        {
            Client currentClient = clientQueue.Dequeue();

            Console.WriteLine($"Администратор обслуживает клиента {currentClient.Name} ({currentClient.ServiceType}).");
            DisplayQueueStatus();
        }
        else
        {
            Console.WriteLine("Очередь пуста. Нет клиентов для обслуживания.");
        }
    }

    private void DisplayQueueStatus()
    {
        if (clientQueue.Count > 0)
        {
            Console.WriteLine("Текущее состояние очереди:");
            foreach (var client in clientQueue)
            {
                Console.WriteLine($"Клиент {client.Name} ({client.ServiceType})");
            }
        }
        else
        {
            Console.WriteLine("Очередь пуста.");
        }
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("1. Добавить клиента в очередь");
            Console.WriteLine("2. Обслужить следующего клиента");
            Console.WriteLine("3. Выйти");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите ваше имя: ");
                    string name = Console.ReadLine();

                    Console.Write("Выберите услугу (Кредитование, Открытие вклада, Консультация): ");
                    string serviceType = Console.ReadLine();

                    bank.EnqueueClient(name, serviceType);
                    break;

                case "2":
                    bank.ServeNextClient();
                    break;

                case "3":
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Некорректный ввод. Пожалуйста, выберите действие 1, 2 или 3.");
                    break;
            }
        }
    }
}
