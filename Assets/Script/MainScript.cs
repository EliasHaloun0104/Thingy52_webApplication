using System;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class MainScript : MonoBehaviour
{
    [SerializeField] public Camera mainCam;
    [SerializeField] public Canvas[] canvas;
    [SerializeField] public float speed;
    [SerializeField] public Queue<Indicator> records;
    [SerializeField] public Indicator lastRecords;
    public bool posting;
    [SerializeField] TextMeshProUGUI text;


    VideoPlayer myVideoPlayer;

    //Move Camera
    bool isMoving;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        records = new Queue<Indicator>();
        StartCoroutine(Get());
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, target, 1);
            if (mainCam.transform.position.Equals(target))
            {
                isMoving = false;
            }
        }
        
    }

    

    public void GoTo(int index)
    {
        if (!isMoving)
        {
            target = canvas[index].transform.position;
            target.z -= 10;
            isMoving = true;
            if(index == 2)
            {
                var vid = FindObjectOfType<VideoPlayer>();
                vid.Play();
            }
            if(index == 0)
            {
                var vid = FindObjectOfType<VideoPlayer>();
                vid.Pause();
            }
        }
        
    }


    public IEnumerator Get()
    {
        
        posting = true;
        var request = HttpRequest.Get();
        
        yield return request.SendWebRequest();
        
 
        var json = request.downloadHandler.text;
        json = json.Substring(1, json.Length - 2);
        json = json.Replace("\\", "");

        var arr = json.ToString().Split(new string[] { "{", "}" }, StringSplitOptions.None);
        var date = "";
        var time = "";
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Length == 0)
                continue;
            else if (arr[i].Contains("-"))
            {
                var value = arr[i].Replace("\"", "");
                value = value.Replace(":", "");
                value = value.Replace(",", "");
                date = value;
            }else if (arr[i].Contains("_"))
            {
                var value = arr[i].Replace("\"", "");
                
                value = value.Replace(",", "");
                value = value.Substring(0, value.Length - 5);
                time = value;
            }
            else
            {
                var value = arr[i].Replace("\"", "");
                var small = value.ToString().Split(new string[] { ":", "," }, StringSplitOptions.None);
                
                lastRecords = new Indicator();
                
                float.TryParse(small[1], out float num);
                lastRecords.Eco2 = float.Parse(small[1]);
                lastRecords.Temp = float.Parse(small[3]);
                float.TryParse(small[5], out num);
                lastRecords.Tvoc = num;
                lastRecords.DateAndTime = date + "\n" + time;
                
                records.Enqueue(lastRecords);

                if (records.Count > 11)
                {
                    records.Dequeue();
                }
            }
        }

        text.text = "Last Reading:\n " + lastRecords.Stringfy();
        posting = false;
        yield return new WaitForSeconds(2f);
        StartCoroutine(Get());
    }
}
