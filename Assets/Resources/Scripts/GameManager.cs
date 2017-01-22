using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public Material blueMat;
    public Material redMat;
    public Material greenMat;
    public Material yellowMat;

    protected override void Awake()
    {
        base.Awake();

        blueMat = Resources.Load<Material>("Materials/BlueMat");
        redMat = Resources.Load<Material>("Materials/RedMat");
        greenMat = Resources.Load<Material>("Materials/GreenMat");
        yellowMat = Resources.Load<Material>("Materials/YellowMat");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        //CameraFollow camera = Camera.main.gameObject.GetComponent<CameraFollow>();
        Camera[] cameras = new Camera[2];
        Camera.GetAllCameras(cameras);

        foreach (Camera camera in cameras)
        {
            if (camera != null)
            {
                CameraFollow cf = camera.gameObject.GetComponent<CameraFollow>();
                if (cf != null)
                    cf.isPlaying = false;
            }
        }

        //Display Game Over


        GameOverPanel.instance.EnableGameOverPanel();

        //SceneTransitionManager.instance.ReloadRoom();
    }
}