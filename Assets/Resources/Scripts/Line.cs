using UnityEngine;

public class Line : MonoBehaviour
{

    public LineColor color;
    public float angle;

    private Camera mainCamera;
    private Vector3 cameraPosition;

    /// <summary>
    /// Retrieve main camera on start
    /// </summary>
    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void CreateLine(float x, float y, float angle, LineColor color, Material mat)
    {
        transform.position = new Vector2(x, y);
        transform.Rotate(Vector3.forward, angle);
        this.color = color;
        this.angle = angle;
        GetComponent<SpriteRenderer>().material = mat;
    }
    
    /// <summary>
    /// When the line is offscreen
    /// </summary>
    public void LateUpdate()
    {
        if (mainCamera != null)
        {
            cameraPosition = mainCamera.gameObject.transform.position;
      
            if (cameraPosition.x - transform.position.x > 30)
            {
                Destroy(gameObject);
            }
        }
    }
}
