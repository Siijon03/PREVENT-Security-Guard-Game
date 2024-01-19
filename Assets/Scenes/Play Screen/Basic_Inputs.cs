using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basic_Inputs : MonoBehaviour
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
}
