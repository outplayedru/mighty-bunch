using System;

namespace ConsoleApp1
{
    class Program
    {
        interface IHomework
        {
            public void DoHomework();  
        }

        class Homework : IHomework
        {
            public void DoHomework()
            {
                Console.WriteLine("Пришлось сделать самому.........");
            }
        }

        class SnatchHomework : IHomework
        {
            Random rand = new Random();
            Homework homework = new Homework();
            public void DoHomework()
            {
                if (rand.Next(0,2) == 0)
                {
                    homework.DoHomework();
                    return;
                }
                else  
                    Console.WriteLine("Задание выполнено"); 
            }
        }

        static void Main(string[] args)
        {
            IHomework homework = new SnatchHomework();
            homework.DoHomework();
        }
    }
}
