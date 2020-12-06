using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] public GameObject mainGrid;
    // Start is called before the first frame update
    void Start()
    {
        var startX = -6;
        var startY = -4;
        var xLength = 12;
        var yLength = 8;

        var clone = Instantiate(mainGrid, transform);
        var line = clone.GetComponent<LineRenderer>();
        //Main x,y
        line.positionCount = 3;
        line.SetPosition(0, new Vector3(startX + xLength, startY));
        line.SetPosition(1, new Vector3(startX, startY));
        line.SetPosition(2, new Vector3(startX, startY + yLength));


        for (int i = 0; i < yLength; i++)
        {
            startY += 1;
            clone = Instantiate(mainGrid, transform);
            line = clone.GetComponent<LineRenderer>();
            line.startWidth = 0.02f;
            line.endWidth = 0.02f;
            line.SetPosition(0, new Vector3(startX, startY));
            line.SetPosition(1, new Vector3(startX + xLength, startY));
        }

        startY -= yLength;
        for (int i = 0; i < xLength; i++)
        {
            startX += 1;
            clone = Instantiate(mainGrid, transform);
            line = clone.GetComponent<LineRenderer>();
            line.startWidth = 0.04f;
            line.endWidth = 0.04f;
            line.SetPosition(0, new Vector3(startX, startY));
            line.SetPosition(1, new Vector3(startX, startY + yLength));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
