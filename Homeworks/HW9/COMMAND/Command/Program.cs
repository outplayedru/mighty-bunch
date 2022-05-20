using System;
using System.Collections.Generic;

namespace Command
{
    public interface IOrder
    {
        void OrderTransfer();
    }

    class Order : IOrder
    {
        private Сhef chef;
        private string a;

        public Order(Сhef chef, string a)
        {
            this.chef = chef;
            this.a = a;
        }

        public void OrderTransfer()
        {
            Console.WriteLine("Официант принял заказ и передает его на кухню(" + a + ")");
            chef.Cooking(this.a);
            Console.WriteLine("Официант принес клиенту :" + a);
            Console.WriteLine();
        }
    }

    class Waiter
    {
        private List<IOrder> orderList = new List<IOrder>();

        public void AddNewOrder(IOrder command)
        {
            orderList.Add(command);
        }

        public void CheckOrder()
        {
            Console.WriteLine("Мы начали принимать заказы");

            foreach (IOrder command in orderList)
                command.OrderTransfer();

            Console.WriteLine("Мы закрываемся");
        }
    }

    class Сhef
    {
        string name;

        public Сhef(string name)
        {
            this.name = name;
        }
        public void Cooking(string a)
        {
            Console.WriteLine("Повар " + name + " готовит: " + a);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Waiter waiter = new Waiter();
            
            Сhef chef = new Сhef("Олег");

            waiter.AddNewOrder(new Order(chef, "Стейк"));
            waiter.AddNewOrder(new Order(chef, "Салат"));
            waiter.AddNewOrder(new Order(chef, "Суп"));
            waiter.AddNewOrder(new Order(chef, "Пицца"));
            waiter.AddNewOrder(new Order(chef, "Чебурек"));
            waiter.AddNewOrder(new Order(chef, "Чебупели"));
            waiter.AddNewOrder(new Order(chef, "Хинкали"));
            waiter.AddNewOrder(new Order(chef, "Шашлык"));
            waiter.AddNewOrder(new Order(chef, "Пельмени"));
            waiter.AddNewOrder(new Order(chef, "Шницель"));

            waiter.CheckOrder();
        }
    }
}