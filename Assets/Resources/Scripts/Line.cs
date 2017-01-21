using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineColor color;

    public void CreateLine(float x, float y, float angle, LineColor color, Material mat)
    {
        transform.position = new Vector2(x, y);
        transform.Rotate(Vector3.forward, angle);
        this.color = color;
        GetComponent<SpriteRenderer>().material = mat;
    }
}
