
using System.Collections;
using UnityEngine;

public class SpikeTessilator : MonoBehaviour {

    /// <summary>
    /// Prefab for the spike object to be tiled.
    /// </summary>
    public GameObject spikePrefab;

    private Queue topQueue = new Queue();
    private Queue bottomQueue = new Queue();

    // Constants specific to screen size
    private const float Y_OFFSET = 4.75f;
    private const float X_START = -8.5f;
    private const float X_DELTA = 20f;

    private Camera mainCamera;

    private float previousLoc;
    private float currLoc;

    private GameObject spikeInstance;

    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
		for (float i = X_START; i <= X_START+X_DELTA; i++)
        {
            // Top Spikes
            spikeInstance = Instantiate(spikePrefab);
            spikeInstance.transform.position = new Vector3(i, Y_OFFSET, 0f);
            topQueue.Enqueue(spikeInstance);

            // Bottom Spikes
            spikeInstance = Instantiate(spikePrefab);
            spikeInstance.transform.localScale = 
                new Vector3(spikeInstance.transform.localScale.x, -spikeInstance.transform.localScale.y, spikeInstance.transform.localScale.z);
            spikeInstance.transform.position = new Vector3(i, -Y_OFFSET+2, 0f);
            bottomQueue.Enqueue(spikeInstance);

        }
    }
	
	// Update is called once per frame
	void Update () {
        currLoc = mainCamera.gameObject.transform.position.x;

        if (currLoc-previousLoc > 1)
        {
            //Update top spikes
            spikeInstance = topQueue.Dequeue() as GameObject;
            Vector3 oldPosition = spikeInstance.transform.position;
            spikeInstance.transform.position = new Vector3(oldPosition.x + X_DELTA, oldPosition.y, oldPosition.z);
            topQueue.Enqueue(spikeInstance);

            //Update bottom spikes
            spikeInstance = bottomQueue.Dequeue() as GameObject;
            oldPosition = spikeInstance.transform.position;
            spikeInstance.transform.position = new Vector3(oldPosition.x + X_DELTA, oldPosition.y, oldPosition.z);
            bottomQueue.Enqueue(spikeInstance);

            previousLoc = currLoc;
        }
	}
}
