using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public Material blueMat;
    public Material redMat;
    public Material greenMat;
    public Material yellowMat;
    public Material blueGlowMat;
    public Material redGlowMat;
    public Material greenGlowMat;
    public Material yellowGlowMat;
    public Material blueOuterGlowMat;
    public Material redOuterGlowMat;
    public Material greenOuterGlowMat;
    public Material yellowOuterGlowMat;
    protected override void Awake()
    {
        base.Awake();

        blueMat = Resources.Load<Material>("Materials/BlueMat");
        redMat = Resources.Load<Material>("Materials/RedMat");
        greenMat = Resources.Load<Material>("Materials/GreenMat");
        yellowMat = Resources.Load<Material>("Materials/YellowMat");
        blueGlowMat = Resources.Load<Material>("Materials/BlueGlowMat");
        redGlowMat = Resources.Load<Material>("Materials/RedGlowMat");
        greenGlowMat = Resources.Load<Material>("Materials/GreenGlowMat");
        yellowGlowMat = Resources.Load<Material>("Materials/YellowGlowMat");
        blueOuterGlowMat = Resources.Load<Material>("Materials/BlueOuterGlowMat");
        redOuterGlowMat = Resources.Load<Material>("Materials/RedOuterGlowMat");
        greenOuterGlowMat = Resources.Load<Material>("Materials/GreenOuterGlowMat");
        yellowOuterGlowMat = Resources.Load<Material>("Materials/YellowOuterGlowMat");

        
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

        //Display Game 
        GameOverPanel.instance.EnableGameOverPanel();
    }
}