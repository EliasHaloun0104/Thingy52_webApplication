using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class HttpRequest : MonoBehaviour
{
    public static readonly string API_Base = "https://iot-lab-2fab2-default-rtdb.europe-west1.firebasedatabase.app/thingy/e00f05209a35.json";
    public static readonly string API_Video = "https://firebasestorage.googleapis.com/v0/b/iot-lab-2fab2.appspot.com/o/video.mp4?alt=media&token=c25bf396-cc85-452f-b51d-836c3e73ab8a";


    public static UnityWebRequest Get()
    {

        UnityWebRequest request = new UnityWebRequest(API_Base, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json");
        request.SetRequestHeader("Access-Control-Expose-Headers", "ETag");
        return request;

    }

    public static bool Error(UnityWebRequest request)
    {
        return request.isNetworkError || request.isHttpError;

    }
}
