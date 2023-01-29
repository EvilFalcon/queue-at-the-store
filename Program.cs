using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_at_the_store
{
    internal class Program
    {
        static void Main()
        {
            const string CommandServeClient = "1";
            const string CommandLookqueue = "2";

            int queueCapacity = 10;
            Queue<int> queue = new Queue<int>();
            int shopMoney = 0;

            queue = CreateQueue(queueCapacity);

            while (queue.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"в очереди {queue.Count} человек\n выручка магазина {shopMoney}");
                Console.WriteLine(new string('-', 30));

                Console.WriteLine($"Нажмите любую кнопку для того чтобы обслужить клиента \n");
                Console.ReadKey();
                shopMoney += ServeClient(queue);

                Console.WriteLine("Нажмите любую кнопку для того чтобы продолжить");
                Console.ReadKey();
            }
        }

        private static Queue<int> CreateQueue(int queueCapacity)
        {
            Queue<int> queue = new Queue<int>();
            Random random = new Random();
            int minPurchaseAmount = 10;
            int maxPurchaseAmount = 1000;

            for (int i = queueCapacity; i > 0; i--)
            {
                queue.Enqueue(random.Next(minPurchaseAmount, maxPurchaseAmount));
            }

            return queue;
        }

        private static int ServeClient(Queue<int> queue)
        {
            int clientMoney = queue.Dequeue();
            Console.WriteLine($"вы заработали {clientMoney}");
            return clientMoney;

        }
    }
}
