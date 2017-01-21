using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float velocity;

    private LineColor currColor;
    private SpriteRenderer spriteRenderer;

    // Check if player is riding line
    private bool onTrack;

    // Use this for initialization
    void Start()
    {
        velocity = 1f;
        currColor = LineColor.GREEN;
        spriteRenderer = GetComponent<SpriteRenderer>();

        SwitchColor();
    }

    private void SwitchColor()
    {
        Material mat = null;
        switch (currColor)
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
        spriteRenderer.material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currColor = LineColor.RED;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currColor = LineColor.GREEN;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currColor = LineColor.BLUE;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            currColor = LineColor.YELLOW;
        }
        SwitchColor();
    }
}
