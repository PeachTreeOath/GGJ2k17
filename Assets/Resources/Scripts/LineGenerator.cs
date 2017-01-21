using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : Singleton<LineGenerator>
{

    private GameObject lineFab;
    private GameObject objectFolder;
    private int numLines = 5; // Maybe change to public later

    // Use this for initialization
    void Start()
    {
        lineFab = Resources.Load<GameObject>("Prefabs/Line");
        objectFolder = GameObject.Find("Objects");

        GenStartLines();

        // Genning arbitrary lines until we have a solution for movement
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

    // Create a sequence of starting lines for tutorial. Currently just gens 1 line for testing
    private void GenStartLines()
    {
        GameObject lineObj = Instantiate<GameObject>(lineFab);
        Line line = lineObj.GetComponent<Line>();
        line.CreateLine(-7, 0, 20, LineColor.RED, GameManager.instance.redMat);
        lineObj.transform.SetParent(objectFolder.transform);
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

        // Temp code to gen lines in starting area
        float x = Random.Range(-5, 30);
        // Lines currently cap at 30 deg angle minimums, change as needed
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
