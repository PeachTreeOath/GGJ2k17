using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : Singleton<GameManager> {

    private GameObject lineFab;
    public int numLines = 10;

	// Use this for initialization
	void Start () {
        lineFab = Resources.Load<GameObject>("Prefabs/Line");

        for(int i = 0; i < numLines; i++)
        {
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
