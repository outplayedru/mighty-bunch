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

	public class TcpClient : Reader, Closer
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
/*
public class FileHandler : Reader, Writer
{
	private const int Size = 16;

	public byte[] Read(Stream st)
	{
		Stream s = new MemoryStream();
		for (int i = 0; i < 256; i++)
		{
			s.WriteByte((byte) i);
		}

		s.Position = 0;

		byte[] buf = new byte[st.Length];
		int readBytes = 0;
		long bytesToRead = st.Length;

		do
		{
			int n = st.Read(buf, readBytes, Size);
			readBytes += n;
			bytesToRead -= n;
		} while (bytesToRead > 0);

		return buf;
	}

	public void Write(Stream st, string text)
	{
		byte[] buf = Encoding.UTF8.GetBytes(text);

		int wroteBytes = 0;
		long bytesToWrite = buf.Length;

		do
		{
			st.Write(buf, wroteBytes, Size);
			wroteBytes += Size;
			bytesToWrite -= Size;
		} while (bytesToWrite > 0);
	}
}

public class TCPHandler : Reader, Writer, Closer
{
	public byte[] Read(Stream st)
	{
		// * Implement reading bytes from TCP connection
		return null;
	}
	public void Write(Stream st, string text)
	{
		// * Implement writing string to TCP connection
	}
	
	public void Close(Stream st)
	{
		// * Close stream
		st.Close();
	}
}
*/