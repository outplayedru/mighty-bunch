using System;
using System.Collections.Generic;

namespace FLYWEIGHT
{
	internal class Program
	{
		abstract class Keyboard
		{
			protected int switches;

			public abstract void assemble(string color);
		}

		class Keyboard100Percent : Keyboard
		{
			public Keyboard100Percent()
			{
				switches = 108;
			}

			public override void assemble(string color)
			{
				Console.WriteLine("Изготовлена {0} клавиатура с {1} клавишами", color, switches);
			}
		}

		class Keyboard80Percent : Keyboard
		{
			public Keyboard80Percent()
			{
				switches = 87;
			}

			public override void assemble(string color)
			{
				Console.WriteLine("Изготовлена {0} клавиатура с {1} клавишами", color, switches);
			}
		}


		class KeyboardFactory
		{
			Dictionary<string,Keyboard> keyboards = new Dictionary<string,Keyboard>();

			public KeyboardFactory()
			{
				keyboards.Add("100", new Keyboard100Percent());
				keyboards.Add("80", new Keyboard80Percent());
			}

			public Keyboard GetKeyboard(string key)
			{
				if(keyboards.ContainsKey(key))
					return keyboards[key];
				else
					return null;
			}
		}

		static void Main(string[] args)
		{
			KeyboardFactory keyboardFactory = new KeyboardFactory();
			Keyboard keyboard100Percent = keyboardFactory.GetKeyboard("100");
			keyboard100Percent.assemble("Черная");

			Keyboard keyboard80Percent = keyboardFactory.GetKeyboard("80");
			keyboard80Percent.assemble("Красная");
		}
	}
}
