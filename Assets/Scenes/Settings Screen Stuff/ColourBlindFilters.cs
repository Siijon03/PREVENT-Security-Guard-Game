using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColourBlindFilters : MonoBehaviour
{
    public Toggle toggleNone;
    public Toggle toggleProtanopia;
    public Toggle toggleDeuteranopia;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ToggleBool") == 1)
        {
            toggleNone.isOn = true;
        }
        else
        {
            toggleProtanopia.isOn = false;
        }
        if (PlayerPrefs.GetInt("ToggleBool") == 2)
        {
            toggleProtanopia.isOn = true;
        }
        else
        {
            toggleProtanopia.isOn = false;
        }
        if (PlayerPrefs.GetInt("ToggleBool") == 3)
        {
            toggleDeuteranopia.isOn = true;
        }
        else
        {
            toggleDeuteranopia.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleNone.isOn == true)
        {
            PlayerPrefs.SetInt("ToggleBool", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool", 0);
        }
        if (toggleProtanopia.isOn == true)
        {
            PlayerPrefs.SetInt("ToggleBool", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool", 0);
        }
        if (toggleDeuteranopia.isOn == true)
        {
            PlayerPrefs.SetInt("ToggleBool", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool", 0);
        }
    }
}
