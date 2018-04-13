using UnityEngine;
using UnityEditor;
using System.Collections;

public class DeleteAllData : MonoBehaviour
{
    [MenuItem("Tools/Delete Data")]
    public static void DeleteData()
    {
        Data.DeleteAllData();
    }
}
