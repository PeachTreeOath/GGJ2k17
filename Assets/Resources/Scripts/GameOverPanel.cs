using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : Singleton<GameOverPanel>
{
    bool isGameOver = false;
    private Text[] components;

    protected override void Awake()
    {
        base.Awake();
        components = GetComponentsInChildren<Text>();
        isGameOver = false;


    }
    
    public void EnableGameOverPanel()
    {
        isGameOver = true;
        foreach(Text component in components)
        {
            component.enabled = true;
        }
    }

    public void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            SceneTransitionManager.instance.ReloadGame();
        }
    }
}
