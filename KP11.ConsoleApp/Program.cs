// See https://aka.ms/new-console-template for more information

using System.Text;
using KP11.Integration;
using KP11.Integration.Models;
using KP11.Integration.Models.Auth;
using Newtonsoft.Json;

string baseAddress = string.Empty;
bool baseAddressInput = false;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Это пример работы API в консольном приложении");

while (!baseAddressInput)
{
    Console.Write("Напишите адрес, на котором в данный момент работает WebAPI: ");
    baseAddress = Console.ReadLine() ?? string.Empty;

    if (baseAddress != string.Empty)
    {
        /*
        try
        {
            using Ping pinger = new();
            PingReply reply = pinger.Send(baseAddress);
            baseAddressInput = reply.Status == IPStatus.Success;
        }
        catch (PingException)
        {
            Console.WriteLine("Адрес недоступен!");
        }*/
        baseAddressInput = true;
    }
    else
    {
        Console.WriteLine("Адрес не может быть пустым!");   
    }
}

KP11Client client = new(baseAddress);
await client.Authorize(new ClientAuthConfiguration("admin", "admin"));

while (true)
{
    Console.WriteLine("Введите символ для выполнения соответствующего действия из описанных ниже:");
    Console.WriteLine("1. /manuals/get-all/");
    Console.WriteLine("2. /manuals/get/{id}");
    Console.WriteLine("3. /manuals/delete/{id}");
    Console.WriteLine("Введите цифру для выполнения действия из описанных ниже:");

    string input = Console.ReadLine() ?? string.Empty;

    switch (input.ToLower())
    {
        case "1":
            List<Manual> manuals = await API.Manuals.GetAll(client.HttpClient);
            Console.WriteLine(JsonConvert.SerializeObject(manuals));
            break;
        case "2":
            Console.Write("Введите ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Введите число!");
                continue;
            }

            Manual manual = await API.Manuals.Get(client.HttpClient, id);
            Console.WriteLine(JsonConvert.SerializeObject(manual));
            break;
        case "3":
            Console.Write("Введите ID: ");
            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Введите число!");
                continue;
            }

            await API.Manuals.Delete(client.HttpClient, deleteId);
            break;
    }

    Console.ReadKey();
}
