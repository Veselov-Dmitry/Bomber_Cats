using System;
using System.Text;

public class B64X
{
    private static string s_stringKey = "c420dc6a-9217-44a0-af71-8a8fc9b0961d";
    private static byte[] s_bytesKey;

    private static byte[] Key
    {
        get
        {
            if (s_bytesKey == null) s_bytesKey = Encoding.UTF8.GetBytes(s_stringKey);
            return s_bytesKey;
        }
    }


    public static string EncodeFrom(object value)
    {    
        return Convert.ToBase64String(Encode(Encoding.UTF8.GetBytes(value.ToString()), Key));
    }


    public static int DecodeToInt(string value)
    {
        int result;
        int.TryParse(Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), Key)), out result);
        return result;
    }


    public static bool DecodeToBool(string value)
    {
        bool result;
        bool.TryParse(Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), Key)), out result);
        return result;
    }


    public static string DecodeToString(string value)
    {
        return Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), Key));
    }


    //Encrypt - Decrypt
    public static string Encrypt(string value, string key)
    {
        return Convert.ToBase64String(Encode(Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(key)));
    }


    public static string Decrypt(string value, string key)
    {
        return Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), Encoding.UTF8.GetBytes(key)));
    }


    //Encode
    private static byte[] Encode(byte[] bytes, byte[] key)
    {
        var j = 0;
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= key[j];
            if (++j == key.Length) j = 0;
        }
        return bytes;
    }
}
