using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : Singleton<LineGenerator>
{

    private GameObject lineFab;
    private GameObject objectFolder;
    private int numLines = 2; // Maybe change to public later

    // Use this for initialization
    void Start()
    {
        lineFab = Resources.Load<GameObject>("Prefabs/Line");
        objectFolder = GameObject.Find("Objects");

        for (int i = 0; i < numLines; i++)
        {
            GenLine(LineColor.BLUE);
        }

        for (int i = 0; i < numLines; i++)
        {
            GenLine(LineColor.RED);
        }
        for (int i = 0; i < numLines; i++)
        {
            GenLine(LineColor.GREEN);
        }
        for (int i = 0; i < numLines; i++)
        {
            GenLine(LineColor.YELLOW);
        }
    }

    private void GenLine(LineColor color)
    {
        Material mat = null;
        switch (color)
        {
            case LineColor.RED:
                mat = GameManager.instance.redMat;
                break;
            case LineColor.GREEN:
                mat = GameManager.instance.greenMat;
                break;
            case LineColor.BLUE:
                mat = GameManager.instance.blueMat;
                break;
            case LineColor.YELLOW:
                mat = GameManager.instance.yellowMat;
                break;

        }

        float x = Random.Range(-10, 10);
        float angle = Random.Range(30, 150);

        GameObject lineObj = Instantiate<GameObject>(lineFab);
        Line line = lineObj.GetComponent<Line>();
        line.CreateLine(x, 0, angle, color, mat);
        lineObj.transform.SetParent(objectFolder.transform);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
