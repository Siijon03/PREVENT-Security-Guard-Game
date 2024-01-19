using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderValue : MonoBehaviour
{
    public TextMeshProUGUI VolumeText;

    // Start is called before the first frame update
    void Start()
    {
        VolumeText = GetComponent<TextMeshProUGUI>();
    }

    public void VolTextUpdate(float SliderLevel)
    {
        VolumeText.text = ("Current Volume: " + Mathf.RoundToInt(SliderLevel * 100) + "%");
    }
}
