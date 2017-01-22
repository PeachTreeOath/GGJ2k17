using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : Singleton<GameOverPanel>
{
    private Text[] components;

    protected override void Awake()
    {
        base.Awake();
        components = GetComponentsInChildren<Text>();


    }
    
    public void EnableGameOverPanel()
    {
        foreach(Text component in components)
        {
            component.enabled = true;
        }
    }
}
