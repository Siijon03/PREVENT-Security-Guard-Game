using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    //Called When the Player Hits the 'Ready' Button.
    public void OnLoadLevelButton()
    {
        SceneManager.LoadScene("Level 1");
        Debug.Log("Loaded up The First Level!");
    }
}
