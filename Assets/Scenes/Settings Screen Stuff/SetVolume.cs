using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SetVolume : MonoBehaviour
{
    //Getting our Audio Mixer and Slider Object.
    public AudioMixer Mixer;
    public Slider slider;

    //Also Let's Get the Slider's Value for our Volume Percentage.
    public GameObject VolumeText;


    void Start()
    {
        //This will Get the Set Float Value from the Slider.
        slider.value = PlayerPrefs.GetFloat("MusicVolume", slider.value);

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }

    }
     void Update()
    {
        
    }

    //Passing the Slider's Level as A parameter.
    public void SetVolLevel(float SliderLevel)
    {
        //Represents the Slider Volume by a Logirithm of 10 and Multiplies it by 20, changes the value to -80 to 0.
        Mixer.SetFloat("MusicVolume", Mathf.Log10(SliderLevel) * 20);
        //Basic Testing
        Debug.Log("The Slider level is " + SliderLevel);

        SaveVolume();

    }

    public void VolTextUpdate(float SliderLevel)
    {
        VolumeText.GetComponent<TextMeshProUGUI>().text = "Current Volume: " + Mathf.RoundToInt(SliderLevel * 100) + "%";
        
    }

    private void SaveVolume()
    {
        //This will Save the Volume to the Player's Preferences.
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }

    private void LoadVolume()
    {
        //This will keep the Music Volume Contast throughout the Game.
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        AudioListener.volume = slider.value;
    }

    





}
