using System;
using UnityEngine;

public class LineGenerator : Singleton<LineGenerator>
{

    public  GameObject lineFab;

    private GameObject objectFolder;
    public int numLines = 10; // Maybe change to public later

    private float previousCamLoc = 0;
    private float currCamLoc = 0;

    /// <summary>
    /// Exposes the delta between camera positions required to generate a new line. 
    /// Every LINE_DELTA units, a new line is created.
    /// </summary>
    public int LINE_DELTA = 2;

    // Use this for initialization
    void Start()
    {
        //lineFab = Resources.Load<GameObject>("Prefabs/Line");
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
        GameObject redLineObj = Instantiate<GameObject>(lineFab);
        Line redLine = redLineObj.GetComponent<Line>();
        redLine.CreateLine(-7, 0, 20, LineColor.RED);
        redLineObj.transform.SetParent(objectFolder.transform);

        GameObject greenLineObj = Instantiate<GameObject>(lineFab);
        Line greenLine = greenLineObj.GetComponent<Line>();
        greenLine.CreateLine(0, 0, -20, LineColor.GREEN);
        greenLineObj.transform.SetParent(objectFolder.transform);

        GameObject blueLineObj = Instantiate<GameObject>(lineFab);
        Line blueLine = blueLineObj.GetComponent<Line>();
        blueLine.CreateLine(7, 0, 40, LineColor.BLUE);
        blueLineObj.transform.SetParent(objectFolder.transform);

        GameObject yellowLineObj = Instantiate<GameObject>(lineFab);
        Line yellowLine = yellowLineObj.GetComponent<Line>();
        yellowLine.CreateLine(14, 0, -30, LineColor.YELLOW);
        yellowLineObj.transform.SetParent(objectFolder.transform);
    }

    public Line GenPreviewLine(Transform parentTransform)
    {
        LineColor color = GetRandomColor();
        Material mat = GetMaterialFromColor(color);

        // Lines currently cap at 30 deg angle minimums, change as needed
        float angle = UnityEngine.Random.Range(-60, 60);

        while (angle > -30 && angle < 30)
        {
            angle = UnityEngine.Random.Range(-60, 60);
        }

        GameObject lineObj = Instantiate<GameObject>(lineFab);
        Line line = lineObj.GetComponent<Line>();
        line.CreateLine(parentTransform.position.x, parentTransform.position.y, angle, color);
        line.GetComponent<BoxCollider2D>().enabled = false;
        line.transform.SetParent(parentTransform);
        line.transform.localScale = new Vector3(line.transform.localScale.x, 5, line.transform.localScale.z);
        return line;
    }

    public void GenLine(LineColor color)
    {
        Material mat = GetMaterialFromColor(color);
        GenLine(color, UnityEngine.Random.Range(15, 90));
    }

    public void GenLine(LineColor color, float x)
    {
        Material mat = GetMaterialFromColor(color);

        // Lines currently cap at 30 deg angle minimums, change as needed
        float angle = UnityEngine.Random.Range(-60, 60);

        while (angle > -30 && angle < 30)
        {
            angle = UnityEngine.Random.Range(-60, 60);
        }

        GameObject lineObj = Instantiate<GameObject>(lineFab);
        Line line = lineObj.GetComponent<Line>();
        line.CreateLine(x, 0, angle, color);
        lineObj.transform.SetParent(objectFolder.transform);
    }

    /// <summary>
    /// Create a line using the provided camera offset. 
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="color"></param>
    private void GenLineAt(float offset, LineColor color)
    {
        Material mat = GetMaterialFromColor(color);
        // Temp code to gen lines in starting area
        float x = UnityEngine.Random.Range(offset + 90, offset + 90);
        // Lines currently cap at 30 deg angle minimums, change as needed

        GenLine(color, x);

        // float angle = Random.Range(50, 130);

        // GameObject lineObj = Instantiate<GameObject>(lineFab);
        // Line line = lineObj.GetComponent<Line>();
        // line.CreateLine(x, 0, angle, color, mat);
        // lineObj.transform.SetParent(objectFolder.transform);
    }

    /// <summary>
    /// Generates a random line color.
    /// </summary>
    /// <returns></returns>
    public LineColor GetRandomColor()
    {
        switch (UnityEngine.Random.Range(1, 5))
        {
            case 1:
                return LineColor.BLUE;
            case 2:
                return LineColor.GREEN;
            case 3:
                return LineColor.RED;
            case 4:
                return LineColor.YELLOW;
            default:
                return LineColor.BLUE;
        }
    }

    /// <summary>
    /// Retrieve the colored material given the proveded identifier.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private Material GetMaterialFromColor(LineColor color)
    {
        Material mat = null;
        switch (color)
        {
            case LineColor.RED:
                mat = GameManager.instance.redGlowMat;
                break;
            case LineColor.GREEN:
                mat = GameManager.instance.greenGlowMat;
                break;
            case LineColor.BLUE:
                mat = GameManager.instance.blueGlowMat;
                break;
            case LineColor.YELLOW:
                mat = GameManager.instance.yellowGlowMat;
                break;
        }
        return mat;
    }
    
    // Update is called once per frame
    void Update()
    {
        currCamLoc = Camera.main.gameObject.transform.position.x;
        if (currCamLoc - previousCamLoc > LINE_DELTA)
        {
            GenLineAt(currCamLoc, GetRandomColor());

            previousCamLoc = currCamLoc;
        }
    }
}
