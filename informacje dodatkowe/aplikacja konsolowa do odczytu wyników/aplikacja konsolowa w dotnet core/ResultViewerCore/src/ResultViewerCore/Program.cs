using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultViewerCore
{
    public static class Downloader
    {
        public async static Task<string> Connect(int count)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var uri = new Uri(string.Format($"http://itadscanner.azurewebsites.net/result/ijfdnjk439/{count}?format=json", string.Empty));
            return await Task.Run(() => client.GetStringAsync(uri));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Podaj ilosc uzytkownikow do wybrania: ");
                var result = JsonConvert.DeserializeObject<UserResponse>(Downloader.Connect(Convert.ToInt32(Console.ReadLine())).Result);
                Console.Clear();

                Console.WriteLine($"Wyniki z godziny: {DateTime.Now.TimeOfDay}\n");

                if (result != null)
                {
                    foreach (var user in result.list.Select((value, index) => new { value, index }))
                    {
                        if (user.value.usedQrCodes == null)
                            user.value.usedQrCodes = "0";

                        Console.WriteLine($"{user.index + 1}. {user.value.username} -punkty: {user.value.points}  -ilosc kodow: {user.value.usedQrCodes.Split(',').Count()-1}");
                    }
                }
                else
                {
                    Console.WriteLine("Brak użytkownikow");
                }

                Console.WriteLine("\nNacisnij dowolny klawisz aby wyszukac jeszcze raz");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
