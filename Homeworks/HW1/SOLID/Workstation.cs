using System;

namespace SOLID_Simple
{
	public interface Monitor
	{
		public void Show();
	}

	public interface Keyboard
	{
		public int KeysNumber();
	}

	public class SimpleKeybord : Keyboard
	{
		private int _keysNumber;

		public SimpleKeybord(int n)
		{
			_keysNumber = n;
		}

		public int KeysNumber()
		{
			return _keysNumber;
		}
	}

	public class Monitor4K : Monitor
	{
		public Monitor4K()
		{
		}

		public void Show()
		{
			Console.WriteLine("Doing some work");
		}
	} 

	public class Workstation
	{
		private Keyboard _keyboard;
		private Monitor _monitor;

		public Workstation(Keyboard kb, Monitor mn)
		{
			_keyboard = kb;
			_monitor = mn;
		}
	}
}