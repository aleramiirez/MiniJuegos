using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int calidad;

    private void Start()
    {
        calidad = PlayerPrefs.GetInt("QualityNumber", 2);
        dropdown.value = calidad;
        SetQuality();
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("QualityNumber", dropdown.value);
        calidad = dropdown.value;
    }
}
