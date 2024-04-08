using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
