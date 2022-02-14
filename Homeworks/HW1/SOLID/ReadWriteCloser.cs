using System.IO;

namespace SOLID
{
	/*
	 ! Large interface which can be easily split into separated interfaces

	public interface ReadWriteCloser
	{
		public void Close(Stream st);
		public byte[] Read(Stream st);
		public void Write(Stream st, string text);
	}
	 */

	public interface Reader
	{
		public byte[] Read(Stream st);
	}

	public interface Writer
	{
		public void Write(Stream st, string text);
	}

	public interface Closer
	{
		public void Close(Stream st);
	}

	public class FaxReadWriter : Reader, Writer
	{
		public void Write(Stream st, string text)
		{
			// * Write text to fax stream
		}
		
		public byte[] Read(Stream st)
		{
			// * Read some text from fax stream
			return null;
		}
	}
	
	public class FileWriter : Writer
	{
		public void Write(Stream st, string text)
		{
			// * Write text to file stream
		}
	}

	public class HttpClient : Reader, Closer
	{
		public byte[] Read(Stream st)
		{
			// * Read some text from tcp stream
			return null;
		}

		public void Close(Stream st)
		{
			// * Close tcp stream
		}
	}
}