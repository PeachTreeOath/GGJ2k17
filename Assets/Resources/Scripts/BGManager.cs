using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour {

    public int numBgs;
    private GameObject bgFab;

	// Use this for initialization
	void Start () {
        bgFab = Resources.Load<GameObject>("Prefabs/Background");
        float width = bgFab.GetComponent<SpriteRenderer>().bounds.size.x;
        float currX = 0;
		for(int i = 0; i < numBgs; i++)
        {
            GameObject newBG = Instantiate<GameObject>(bgFab);
            newBG.transform.position = new Vector2(currX, 0);
            currX += width;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
