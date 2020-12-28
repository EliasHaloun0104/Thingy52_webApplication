using System.Collections;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public static int range = 6;
    [SerializeField] Point[] points;
    [SerializeField] LineRenderer line;

    int visualteIndex;

    bool update;
    [SerializeField] int updateIndex;

    [SerializeField] MainScript mainScript;

    private IEnumerator Start()
    {
        updateIndex = -1;
        mainScript = FindObjectOfType<MainScript>();
        yield return new WaitUntil(() => updateIndex > -1);
        while (true)
        {
            yield return new WaitForSeconds(2f);
            SetPoints(updateIndex);
        }
    }

    public void SetPoints(int index)
    {
        /*
        foreach (var item in points)
        {
            item.SetOriginalPosition();
        }
        */

        var records = mainScript.records.ToArray();
        
        var minTemp = records[0].Temp;
        var maxTemp = records[0].Temp;

        var minEco2 = records[0].Eco2;
        var maxEco2 = records[0].Eco2;
        
        var minTvoc = records[0].Tvoc;
        var maxTvoc = records[0].Tvoc;

        foreach (var item in records)
        {
            if (item.Temp < minTemp) minTemp = item.Temp;
            if (item.Temp > maxTemp) maxTemp = item.Temp;
            
            if (item.Eco2 < minEco2) minEco2 = item.Eco2;
            if (item.Eco2 > maxEco2) maxEco2 = item.Eco2;
            
            if (item.Tvoc < minTvoc) minTvoc = item.Tvoc;
            if (item.Tvoc > maxTvoc) maxTvoc = item.Tvoc;
        }

        updateIndex = records.Length;
        visualteIndex = index;
        for (int i = 0; i < points.Length; i++)
        {
            if(visualteIndex == 0)
                points[i].SetTarget(Vector3.up * (range * (records[i].Temp - minTemp) / (maxTemp - minTemp) ), records[i].Stringfy());
            else if (visualteIndex == 1)
                points[i].SetTarget(Vector3.up * (range * (records[i].Eco2 - minEco2) / (maxEco2 - minEco2)), records[i].Stringfy());
            else if (visualteIndex == 2)
            {
                points[i].SetTarget(Vector3.up * (range * (records[i].Tvoc - minTvoc) / (maxTvoc - minTvoc + 0.01f)), records[i].Stringfy());
            }
        }
        update = true;
    }

    private void Update()
    {
        if (!update) return;

        for (int i = 0; i < updateIndex; i++)
        {
            line.SetPosition(i, Vector3.MoveTowards(line.GetPosition(i), points[i].transform.position, 1));
        }
    }



  


}
