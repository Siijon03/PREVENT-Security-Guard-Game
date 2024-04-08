using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_Button : MonoBehaviour
{
    
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Starting Screen");
            Debug.Log("Loading");
        }
    }

    //Called When the Player Hits the 'Play' Button.
    public void OnHomeButton()
    {
        SceneManager.LoadScene("Starting Screen");
        Debug.Log("Loaded up The Starting Screen!");
    }
}
