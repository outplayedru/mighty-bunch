using System;

namespace FACADE
{
	internal class Program
	{
		class Facade
		{
			public Facade(Logistic logistic, Maintenance maintenance, Workers workers)
			{
				this.logistic = logistic;
				this.maintenance = maintenance;
				this.workers = workers;
			}

			Logistic logistic;
			Maintenance maintenance;
			Workers workers;

			public void Manufacture()
			{
				logistic.MaterialsDelivery();
				maintenance.Repair();
				workers.DoWork();
			}
		}

		class Logistic
		{
			public void MaterialsDelivery()
			{
				Console.WriteLine("Доставка сырья");
			}
		}

		class Maintenance
		{
			public void Repair()
			{
				Console.WriteLine("Обслуживание оборудования");
			}
		}

		class Workers
		{
			public void DoWork()
			{
				Console.WriteLine("Работа персонала");
			}
		}

		static void Main(string[] args)
		{
			Workers workers = new Workers();
			Maintenance maintenance = new Maintenance();
			Logistic logistic = new Logistic();

			Facade facade = new Facade(logistic, maintenance, workers);
			facade.Manufacture();
		}
	}
}
