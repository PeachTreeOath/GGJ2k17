using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    //Transition from game to title screen
    public void LoadTitleScreen()
    {
      //  SceneManager.UnloadSceneAsync("Game");
      //  SceneManager.LoadScene("TitleScreen", LoadSceneMode.Additive);
    }

    //Transition from title screen to game
    public void LoadGame()
    {
      //  SceneManager.UnloadSceneAsync("TitleScreen");
       // SceneManager.LoadScene("Games", LoadSceneMode.Additive);
    }

    //Reload the game without returning to title screen
    public void ReloadGame()
    {
        //SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadScene("Game");
    }
}