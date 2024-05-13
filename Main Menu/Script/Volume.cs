using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;

    public float sliderValue;

    public Image imageMute;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void CheckMute()
    {
        if (slider.value == 0)
        {
            imageMute.enabled = true;
        } 

        else
        {
            imageMute.enabled = false;
        }
    }
}
