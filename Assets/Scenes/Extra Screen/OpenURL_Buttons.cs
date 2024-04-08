using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void OpenPREVENTUrl()
    {
        Application.OpenURL("https://www.gov.uk/government/publications/channel-and-prevent-multi-agency-panel-pmap-guidance/channel-duty-guidance-protecting-people-susceptible-to-radicalisation-accessible");
    }

    public void OpenActEarlyUrl() 
    {
        Application.OpenURL("https://actearly.uk");
    }

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
