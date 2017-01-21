using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private GameObject cam;
    private GameObject lBorder;
    private GameObject rBorder;

    public float speed;
    private float yValue;
    private float zValue;
    public float leftClamp;
    public float rightClamp;

    // Use this for initialization
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        lBorder = GameObject.Find("LBorder");
        rBorder = GameObject.Find("RBorder");
        yValue = transform.position.y;
        zValue = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        lBorder.transform.position = new Vector3(leftClamp + cam.transform.position.x, yValue, zValue);
        rBorder.transform.position = new Vector3(rightClamp + cam.transform.position.x, yValue, zValue);
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - speed * Time.deltaTime, leftClamp + cam.transform.position.x, rightClamp + cam.transform.position.x), yValue, zValue);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed * Time.deltaTime, leftClamp + cam.transform.position.x, rightClamp + cam.transform.position.x), yValue, zValue);
        }

        // Detect spacebar / enter to drop line
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LineGenerator instance = LineGenerator.instance;
            instance.GenLine(instance.GetRandomColor(), (float) transform.position.x);
        }
    }
}
