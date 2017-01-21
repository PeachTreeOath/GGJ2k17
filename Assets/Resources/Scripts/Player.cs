﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 2f; // Watch out for stale inspector data here...

    private LineColor currColor;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        currColor = LineColor.RED;
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

        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // When colliding with a new line and colors match, absorb angle and rotate
        Line line = col.GetComponent<Line>();
        if (line != null)
        {
            if (line.color == currColor)
            {
                transform.rotation = line.transform.rotation;
                if (transform.rotation.eulerAngles.z > 90)
                {
                    transform.Rotate(Vector3.forward, -180);
                }
            }
        }
    }
}