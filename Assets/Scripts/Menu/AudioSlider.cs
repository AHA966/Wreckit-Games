using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    /**
    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource Source;

    [SerializeField]
    private AudioMixMode MixMode;

    private float value;


    public void onChangeSlider(float value)
    {

        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume", (-80 + value * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(value) * 20);
                break;
        }

        //PlayerPrefs.SetFloat("Volume", Value);
        //PlayerPrefs.Save();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Mixer.SetFloat("Volume", Mathf.Log10(PrayerPrefs.GetFloat("Volume", 1) * 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
    **/
}
