using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void Backbutton()
    {
        SceneManager.LoadScene("Starting Screen");
        Debug.Log("Back to Home!");
    }
}
