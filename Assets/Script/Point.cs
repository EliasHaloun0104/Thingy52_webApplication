using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Vector3 orginalPosition;
    private Vector3 target;
    private string info;

    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        orginalPosition = transform.position;
        target = orginalPosition;
    }

    public void SetOriginalPosition()
    {
        transform.position = orginalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 3*Time.deltaTime);
    }

    public void SetTarget(Vector3 target, string info)
    {
        this.target = orginalPosition + target;
        this.info = info;
    }

    private void OnMouseOver()
    {

        text.text = info;
    }

    private void OnMouseExit()
    {
        text.text = "";
    }
}
