
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float distFromPlayer;
    private GameObject player;
    public bool isPlaying = true;

    void Start()
    {
        player = GameObject.Find("Player");
        distFromPlayer = transform.position.x - player.transform.position.x;
    }

    void LateUpdate()
    {
        if (isPlaying)
            transform.position = new Vector3(player.transform.position.x + distFromPlayer, transform.position.y, transform.position.z);
    }

    
}
