using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : Singleton<GameManager> {

    private GameObject lineFab;

	// Use this for initialization
	void Start () {
        lineFab = Resources.Load<GameObject>("Prefabs/Line");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
