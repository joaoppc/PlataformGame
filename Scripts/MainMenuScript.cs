using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

public void StartGame()
{   
    GameState.score = 0;
    GameState.life = 3;
    SceneManager.LoadScene(1);
}


public void QuitGame()
{
    Application.Quit();
}
}
