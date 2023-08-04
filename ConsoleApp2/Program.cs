using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Statistic statistic = new Statistic();
            statistic.LoadDefaultValues();

            var maxHeroes = statistic.GetMaxRate(ResultType.Win);
            if (maxHeroes == null)
            {
                Console.WriteLine($"Нет игроков с победами");
            }
            else
            {
                foreach (var maxHeroe in maxHeroes)
                {
                    Console.WriteLine($"Максимальное количество побед {maxHeroe.Count} у героя {maxHeroe.Hero}");
                }
            }

            maxHeroes = statistic.GetMaxRate(ResultType.Lose);
            if (maxHeroes == null)
            {
                Console.WriteLine($"Нет игроков с проигрышами");
            }
            else
            {
                foreach (var maxHeroe in maxHeroes)
                {
                    Console.WriteLine($"Максимальное количество проигрышей {maxHeroe.Count} у героя {maxHeroe.Hero}");
                }
            }


            var minHeroes = statistic.GetMinRate(ResultType.Win);
            if (minHeroes == null)
            {
                Console.WriteLine($"Нет игроков с победами");
            }
            else
            {
                foreach (var minHeroe in minHeroes)
                {
                    Console.WriteLine($"Минимальноее количество побед {minHeroe.Count} у героя {minHeroe.Hero}");
                }
            }

            minHeroes = statistic.GetMinRate(ResultType.Lose);
            if (minHeroes == null)
            {
                Console.WriteLine($"Нет игроков с проигрышами");
            }
            else
            {
                foreach (var minHeroe in minHeroes)
                {
                    Console.WriteLine($"Минимальноее количество проигрышей {minHeroe.Count} у героя {minHeroe.Hero}");
                }
            }


            Console.WriteLine("oiji");
            Console.ReadLine();

            //его самый успешный герой (с максимальным винрейтом) и самый неуспешный (с минимальным)


            //самый любимый герой(с максимальным количеством сыгранных матчей) и самый нелюбимый(с минимальным)

            //герой с самым большим винстриком (количеством выигрышных матчей подряд)
        }
    }
}
