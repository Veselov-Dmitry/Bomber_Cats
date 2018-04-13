using System;
using System.IO;
using System.Xml.Serialization;

public static class Converter {

	public static byte[] SerializeToByteArray<T>(this T obj) where T : class
	{
		if (obj == null)
		{
			return null;
		}
		using (MemoryStream ms = new MemoryStream())
		{
			var serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(ms, obj);
			return ms.ToArray();
		}
	}

	public static T Deserialize<T>(this byte[] byteArray) where T : class
	{
		if (byteArray == null)
		{
			return null;
		}
		using (MemoryStream memStream = new MemoryStream(byteArray))
		{
			var serializer = new XmlSerializer(typeof(T));
			var obj = (T)serializer.Deserialize(memStream);
			return obj;
		}
	}
}
