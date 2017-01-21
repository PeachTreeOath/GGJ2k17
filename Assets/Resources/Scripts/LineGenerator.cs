using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : Singleton<LineGenerator>
{
    private Material blueMat;
    private Material redMat;
    private Material greenMat;
    private Material yellowMat;

    private GameObject lineFab;
    private GameObject objectFolder;
    private int numLines = 2; // Maybe change to public later

    // Use this for initialization
    void Start()
    {
        // Material is sent from here to the line so we don't have to load resources all the time
        blueMat = Resources.Load<Material>("Materials/BlueMat");
        redMat = Resources.Load<Material>("Materials/RedMat");
        greenMat = Resources.Load<Material>("Materials/GreenMat");
        yellowMat = Resources.Load<Material>("Materials/YellowMat");

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
                mat = redMat;
                break;
            case LineColor.GREEN:
                mat = greenMat;
                break;
            case LineColor.BLUE:
                mat = blueMat;
                break;
            case LineColor.YELLOW:
                mat = yellowMat;
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
