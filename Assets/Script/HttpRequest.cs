using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class HttpRequest : MonoBehaviour
{
    public static readonly string API_Base = "https://organic-food-network-api20201105132615.azurewebsites.net/api/";


    private void LogMessage(string title, string message)
    {
        #if UNITY_EDITOR
                EditorUtility.DisplayDialog(title, message, "Ok");
        #else
		        Debug.Log(message);
        #endif
    }

    
}
