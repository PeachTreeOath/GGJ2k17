using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f; // Watch out for stale inspector data here...
    public float distanceScalar; // Multiplies by X distance to create displayed distance number

    private Line currLine;
    private LineColor currColor;
    private SpriteRenderer spriteRenderer;

    public float distanceTravelled;

    ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        currColor = LineColor.RED;
        spriteRenderer = GetComponent<SpriteRenderer>();

        ps = gameObject.GetComponentInChildren(typeof(ParticleSystem)) as ParticleSystem;

        SwitchColor();

        distanceTravelled = 0f;
    }

    private void SwitchColor()
    {
        Material mat = null;

        Gradient grad = new Gradient();
        var col = ps.colorOverLifetime;
        col.enabled = true;

        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;

        switch (currColor)
        {
            case LineColor.RED:
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
                break;
            case LineColor.GREEN:
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.green, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
                break;
            case LineColor.BLUE:
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.blue, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
                break;
            case LineColor.YELLOW:
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(Color.yellow, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
                break;
        }

        col.color = grad;
        // spriteRenderer.material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("Fire3"))
        {
            currColor = LineColor.RED;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("Fire2"))
        {
            currColor = LineColor.GREEN;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Fire1"))
        {
            currColor = LineColor.BLUE;
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Fire4"))
        {
            currColor = LineColor.YELLOW;
        }
        SwitchColor();

        if (currLine != null)
        {
            Vector2 movementVector = currLine.transform.up * speed * Time.deltaTime;
            transform.Translate(movementVector);
        }

        //Have to offset this by the location of the player starting location
        distanceTravelled = (transform.position.x + 7) * distanceScalar;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // When colliding with a new line and colors match, absorb angle and rotate
        Line line = col.GetComponent<Line>();
        if (line != null)
        {
            if (line.color == LineColor.WHITE)
            {
                GameManager.instance.GameOver();
                speed = 0;
                BGManager.instance.scrollSpeed = 0;
            }

            if (line.color == currColor)
            {
                AudioManager.instance.PlaySound("Line_Switch");
                currLine = line;
            }
        }

        if (col.tag.Equals("Border"))
        {

            GameManager.instance.GameOver();
            speed = 0;
            BGManager.instance.scrollSpeed = 0;
        }
    }
}
