
using UnityEngine;

public class LineGenerator : Singleton<LineGenerator>
{

    private GameObject lineFab;
    private GameObject objectFolder;
    private int numLines = 2; // Maybe change to public later

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

    public void GenLine(LineColor color)
    {
        Material mat = GetMaterialFromColor(color);
        // Temp code to gen lines in starting area
        float x = Random.Range(-5, 15);
        // Lines currently cap at 30 deg angle minimums, change as needed
        float angle = Random.Range(30, 150);

        GameObject lineObj = Instantiate<GameObject>(lineFab);
        Line line = lineObj.GetComponent<Line>();
        line.CreateLine(x, 0, angle, color, mat);
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
        float x = Random.Range(offset, offset+10);
        // Lines currently cap at 30 deg angle minimums, change as needed
        float angle = Random.Range(30, 150);

        GameObject lineObj = Instantiate<GameObject>(lineFab);
        Line line = lineObj.GetComponent<Line>();
        line.CreateLine(x, 0, angle, color, mat);
        lineObj.transform.SetParent(objectFolder.transform);
    }

    /// <summary>
    /// Generates a random line color.
    /// </summary>
    /// <returns></returns>
    private LineColor GetRandomColor()
    {
        switch(Random.Range(1, 5))
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
        return mat;
    }

    // Update is called once per frame
    void Update()
    {
        currCamLoc = Camera.main.gameObject.transform.position.x;
        if ( currCamLoc - previousCamLoc > LINE_DELTA)
        {
            GenLineAt(currCamLoc, GetRandomColor());

            previousCamLoc = currCamLoc;
        }
    }
}
