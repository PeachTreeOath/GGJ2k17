using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public LineColor color;
    public float angle;

    public void CreateLine(float x, float y, float angle, LineColor color, Material mat)
    {
        transform.position = new Vector2(x, y);
        transform.Rotate(Vector3.forward, angle);
        this.color = color;
        this.angle = angle;
        GetComponent<SpriteRenderer>().material = mat;
    }
}
