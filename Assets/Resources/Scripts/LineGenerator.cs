using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : Singleton<LineGenerator> {

    private GameObject lineFab;
    private GameObject objectFolder;
    public int numLines = 10;

	// Use this for initialization
	void Start () {
        lineFab = Resources.Load<GameObject>("Prefabs/Line");
        objectFolder = GameObject.Find("Objects");

        for (int i = 0; i < numLines; i++)
        {
            GenLine();
        }
    }

    private void GenLine()
    {
        float x = Random.Range(-10, 10);
        float angle = Random.Range(30,150);

        GameObject lineObj = Instantiate<GameObject>(lineFab);
        Line line = lineObj.GetComponent<Line>();
        line.CreateLine(x, 0, angle, LineColor.GREEN);
        lineObj.transform.SetParent(objectFolder.transform);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
