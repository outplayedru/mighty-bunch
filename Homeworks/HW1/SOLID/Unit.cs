using System;
using System.Threading;


namespace SOLID
{
	// 3. LSP

	public static class Randomer
	{
		private static readonly Random Random = new();

		public static int Next(int from, int to)
		{
			return Random.Next(from, to);
		}
	}

	public class Unit
	{
		public Unit(uint healthPoint)
		{
			HealthPoint = healthPoint;
		}

		public uint HealthPoint { get; }

		public virtual void UseSkill()
		{
			Console.WriteLine("Unskilled unit");
		}

		public virtual void Attack()
		{
			Console.WriteLine("Hand slap");
		}
	}

	public class Knight : Unit
	{
		public Knight(uint healthPoint) : base(healthPoint)
		{
		}

		public override void UseSkill()
		{
			switch (Randomer.Next(0, 3))
			{
				case 0:
					Console.WriteLine("Give friendly minion a shield");
					break;
				case 1:
					Console.WriteLine("Give friendly minion a helmet");
					break;
				case 2:
					Console.WriteLine("Give friendly minion a horse");
					break;
			}
		}

		public override void Attack()
		{
			Console.WriteLine("Attack next 3 enemy's minions");
		}
	}

	public class Wizard : Unit
	{
		public Wizard(uint healthPoint) : base(healthPoint)
		{
		}

		public override void UseSkill()
		{
			switch (Randomer.Next(0, 2))
			{
				case 0:
					Console.WriteLine("Clone friendly minion");
					break;
				case 1:
					Console.WriteLine("Give friendly minion a buff");
					break;
			}
		}

		public override void Attack()
		{
			Console.WriteLine("Cast fireball");
		}
	}

	public static class Game
	{
		public static void Run(params Unit[] units)
		{
			for (int i = 0; i < 3; i++)
			{
				foreach (var unit in units)
				{
					unit.UseSkill();
				}

				foreach (var unit in units)
				{
					unit.Attack();
				}
				
				Console.WriteLine("***");
			}
		}
	}
}