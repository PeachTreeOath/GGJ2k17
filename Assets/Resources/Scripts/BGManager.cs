using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{

    public int numBgs;
    private GameObject bgFab;
    private Transform camPosition;
    private List<GameObject> bgs;
    private float totalWidth;

    // Use this for initialization
    void Start()
    {
        bgs = new List<GameObject>();
        bgFab = Resources.Load<GameObject>("Prefabs/Background");
        camPosition = GameObject.Find("Main Camera").transform;
        float width = bgFab.GetComponent<SpriteRenderer>().bounds.size.x;
        totalWidth = width * numBgs;
        float currX = -10;
        for (int i = 0; i < numBgs; i++)
        {
            GameObject newBG = Instantiate<GameObject>(bgFab);
            newBG.transform.position = new Vector2(currX, 0);
            currX += bgFab.GetComponent<SpriteRenderer>().bounds.size.x;
            bgs.Add(newBG);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject bg in bgs)
        {
            if (bg.transform.position.x < camPosition.transform.position.x - 25)
            {
                bg.transform.position += new Vector3(totalWidth, 0, 0);
            }
        }
    }
}
