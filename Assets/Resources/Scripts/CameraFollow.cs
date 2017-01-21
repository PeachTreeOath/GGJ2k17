using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Camera cam;
    private float distFromPlayer;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        cam = GetComponent<Camera>();
        distFromPlayer = transform.position.x - player.transform.position.x;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + distFromPlayer, transform.position.y, transform.position.z);
    }
}
