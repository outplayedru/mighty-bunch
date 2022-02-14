using System;

namespace SOLID
{
	// 1. SRP
	
	public class Book
	{
		private string _title;
		private string _author;
		private string _text;
		private string _snippet;

		public Book(string title, string author, string text, string snippet)
		{
			_title = title;
			_author = author;
			_text = text;
			_snippet = snippet;
		}

		// Usual internal method
		public bool IsContainsWord(string word)
		{
			return _text.Contains(word);
		}

		public override string ToString()
		{
			return $"{_title}, {_author}, {_snippet}\n{_text}";
		}

		/*
		! Second responsibility to print itself 	 
		public void Print()
		{
			Console.WriteLine(this);
		}
		*/
	}
	
	
	// * Add printer class which implements printer
	public class BookPrinter
	{
		public void ToConsole(Book book)
		{
			Console.WriteLine(book);
		}

		public void ToPrinter(Book book)
		{
			// * Send book to printer device or something else 
		}
	}
}