using System;

namespace SOLID
{
	/*
	 ! Large interface which can be easily split into separated interfaces
	public interface KittenKeeper
	{
		void Feed();
		void Pet();
		void Wash();
		void Squeeze();
	}
	*/

	public interface KittenFeeder
	{
		public void Feed();
	}

	public interface KittenPetter
	{
		public void Pet();
	}

	public interface KittenWasher
	{
		public void Wash();
	}

	public interface KittenSqueezer
	{
		public void Squeeze();
	}

	public class KittenCarer : KittenFeeder, KittenWasher
	{
		public void Feed()
		{
		}

		public void Wash()
		{
		}
	}

	public class KittenLover : KittenFeeder, KittenPetter, KittenSqueezer
	{
		public void Feed()
		{
		}

		public void Pet()
		{
		}

		public void Squeeze()
		{
		}
	}
}