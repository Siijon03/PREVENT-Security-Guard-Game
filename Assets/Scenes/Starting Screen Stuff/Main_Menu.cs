using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //Called When the Player Hits the 'Play' Button.
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("How to Screen");
        Debug.Log("Loaded up The Tutorial!");
    }

    //Used to Load the Settings Screen.
    public void OnSettingsButton ()
    {
        SceneManager.LoadScene("Settings Screen");
        Debug.Log("Loaded up Settings!");
    }

    //To Quit the Game.
    public void OnQuitButton ()
    {
        Application.Quit();
        Debug.Log("Quit the Game!");
    }

}
