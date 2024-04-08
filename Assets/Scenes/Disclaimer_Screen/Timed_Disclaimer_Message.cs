using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timed_Disclaimer_Message : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForUserUserToReadDisclaimer());
    }

    IEnumerator WaitForUserUserToReadDisclaimer()
    {
        yield return new WaitForSeconds(10);

        LoadStartingScreen();
    }

    public void LoadStartingScreen()
    {
        SceneManager.LoadScene("Starting Screen");
    }

}
