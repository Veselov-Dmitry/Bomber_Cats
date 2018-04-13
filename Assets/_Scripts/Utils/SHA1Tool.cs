using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SHA1Tool
{
    const string SALT = "b491811c50cd35c6f526deb0dba46ab8401deff2";
    const string SALT_2 = "b491811c50cd35c6f526deb0dba46ab8401deff1";
    private static byte[] hash;

    public static string GetScoreHash(string gameName, string userid)
    {
 //       Debug.Log("GetScoreHash");
        string s = userid + gameName;
        string temp = SHA1(SHA1(s) + SHA1(SALT));
        return temp;
    }

    public static string GetInitHash(string userid,string userName,string gameName)
	{
		//Debug.Log("GetScoreHash");
        string s = userid + userName + gameName;
		string temp = SHA1(SHA1(s) + SHA1(SALT));
		return temp;
	}
    public static string GetScoreHashGameOver(string id_1, string id_2,string gameName,string result)
	{
//		Debug.Log("GetScoreHash");
        string s = id_1 + id_2 + gameName + result;
		string temp = SHA1(SHA1(s) + SHA1(SALT));
		return temp;
	}


    public static string SHA1(string input)
    {
     //   string input2 = string.Empty;
	//	input2 = input.ToLower();
        using (var sha1 = new SHA1CryptoServiceProvider())
        {
           
            hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
        }
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < hash.Length; i++) sb.AppendFormat("{0:x2}", hash[i]);
        return sb.ToString();
    }
}
