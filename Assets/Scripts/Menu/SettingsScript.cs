﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    
    public const int DEFAULT_QUALITY_LEVEL = 2;
    public const string QUALITY_SETTINGS_KEY = "quality"; 

    public TMPro.TMP_Dropdown QualityDropdown;

    public void Start()
    {
        
        // Load quality from saved value
        QualityDropdown.value = PlayerPrefs.GetInt(QUALITY_SETTINGS_KEY, DEFAULT_QUALITY_LEVEL);
        // Note: the line above does not call "SetQuality" if its value is unchanged so we call it again below
        SetQuality(QualityDropdown.value);
    }

    public void SetQuality(int qualityIndex)
    {
      QualitySettings.SetQualityLevel(qualityIndex);
      PlayerPrefs.SetInt(QUALITY_SETTINGS_KEY, qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
      Screen.fullScreen = isFullScreen;
    }
    
}
