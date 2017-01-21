using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public Material blueMat;
    public Material redMat;
    public Material greenMat;
    public Material yellowMat;

    // Use this for initialization
    void Start()
    {
        blueMat = Resources.Load<Material>("Materials/BlueMat");
        redMat = Resources.Load<Material>("Materials/RedMat");
        greenMat = Resources.Load<Material>("Materials/GreenMat");
        yellowMat = Resources.Load<Material>("Materials/YellowMat");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
