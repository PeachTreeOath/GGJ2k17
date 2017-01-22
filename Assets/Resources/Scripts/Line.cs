using UnityEngine;

public class Line : MonoBehaviour
{

    public LineColor color;
    public float angle;

    private Camera mainCamera;
    private Vector3 cameraPosition;
    private float textureOffset = 0;
    private LineRenderer lineRenderer;
    private SpriteRenderer spriteRenderer;
    public Transform start;
    public Transform end;
    /// <summary>
    /// Retrieve main camera on start
    /// </summary>
    private void Start()
    {
        mainCamera = Camera.main;
        SetupColor(color);
    }
    /*
        public void CreateLine(float x, float y, float angle, LineColor color, Material mat)
        {
            transform.position = new Vector2(x, y);
            transform.Rotate(Vector3.forward, angle);
            this.color = color;
            this.angle = angle;
            GetComponent<SpriteRenderer>().material = mat;
        }
        */

    public void CreateLine(float x, float y, float angle, LineColor color)
    {
        transform.position = new Vector2(x, y);
        transform.Rotate(Vector3.forward, angle);
        
        this.angle = angle;
        
        SetupColor(color);
    }

    private void SetupColor(LineColor color)
    {
    	BoxCollider2D bc2d = gameObject.GetComponent<BoxCollider2D>();

   		Vector2 bc2dSize = bc2d.size;
   		
    	this.color = color;

    	//GetComponent<SpriteRenderer>().material = mat;
    	lineRenderer = gameObject.GetComponent<LineRenderer>();
    	spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        start = transform.Find("Start");
    	end = transform.Find("End");

		lineRenderer.SetPosition(0, start.position);
		lineRenderer.SetPosition(1, end.position);
    	// Material[] mats = new Material[2];
    	// mats[0] = mat;
    	// mats[1] = mat2;
    	//lineRenderer.materials = mats;
    	lineRenderer.startWidth = 0.3f;
    	lineRenderer.endWidth = 0.3f;

    	switch (color)
    	{
    		case LineColor.WHITE:
    			bc2d.enabled = false;
    			lineRenderer.startColor = Color.white;
    			lineRenderer.endColor = Color.white;
    			spriteRenderer.color = Color.white;
    			break;
    	    case LineColor.RED:
    	        lineRenderer.startColor = Color.red;
    	        lineRenderer.endColor = Color.red;
    	        spriteRenderer.color = Color.red;
    	        break;
    	    case LineColor.GREEN:
    	        lineRenderer.startColor = Color.green;
    	        lineRenderer.endColor = Color.green;
    	        spriteRenderer.color = Color.green;
    	        break;
    	    case LineColor.BLUE:
    	        lineRenderer.startColor = Color.blue;
    	        lineRenderer.endColor = Color.blue;
    	        spriteRenderer.color = Color.blue;
    	        break;
    	    case LineColor.YELLOW:
    	        lineRenderer.startColor = Color.yellow;
    	        lineRenderer.endColor = Color.yellow;
    	       	spriteRenderer.color = Color.yellow;
    	        break;
    	}
    }

    void Update()
    {
        textureOffset -= Time.deltaTime * 1f;
        if (textureOffset < -.3f)
        {
            textureOffset += .3f;
        }
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, start.position);
            lineRenderer.SetPosition(1, end.position);
            lineRenderer.materials[1].SetTextureOffset("_MainTex", new Vector2(textureOffset, 0));
        }
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
