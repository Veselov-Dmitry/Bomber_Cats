using UnityEngine;
using LitJson;
using System;

public class Data 
{
    static string SerialiseObject<T>(T obj)
    {
        return JsonMapper.ToJson(obj);
    }

    static T DeserialiseObject<T>(string list)
    {
        return JsonMapper.ToObject<T>(list);
    }

    public static void SetObject<T>(T data, string key)
    {
        SetString(SerialiseObject(data), key);
    }

    public static void SetInt(int data, string key)
    {
        string encodedInt = B64X.EncodeFrom(data);
        PlayerPrefs.SetString(key, encodedInt);
    }

    public static void SetString(string data, string key)
    {
        string encodedString = B64X.EncodeFrom(data);
        PlayerPrefs.SetString(key, encodedString);
    }

    public static void SetBool(bool data, string key)
    {
        SetInt((data) ? 1 : 0, key);
    }

    public static T GetObjectOrNew<T>(string key)
    {
        if (!Data.ContainsKey(key)) return (T)Activator.CreateInstance(typeof(T));
        return DeserialiseObject<T>(GetString(key));
    }

    public static int GetInt(string key)
    {
        int decodedInt = B64X.DecodeToInt(PlayerPrefs.GetString(key));
        return decodedInt;
    }

    public static string GetString(string key)
    {
        string decodedString = B64X.DecodeToString(PlayerPrefs.GetString(key));
        return decodedString;
    }

    public static bool GetBool(string key)
    {
        return GetInt(key) == 0 ? false : true;
    }

    public static bool ContainsKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }
}
