using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Update_Text : MonoBehaviour
{

    public TextMeshPro UpdateText;
    public Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText.GetComponent<SetVolume>();
        
    }

    public void UpdateTextValue(float SliderLevel)
    {
        UpdateText.text = "Volume: "+ VolumeSlider + "%";
    }
}
