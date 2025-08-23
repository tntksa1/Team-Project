using UnityEngine;
using UnityEngine.UI;

public class AudioSliderSwitcher : MonoBehaviour
{
    public Slider volumeSlider;
    private bool controllingMusic = true;

    void Start()
    {
        // افتراضي يتحكم بالموسيقى
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        volumeSlider.value = AudioManager.instance.MusicVolume;
    }

    public void SwitchToMusic()
    {
        controllingMusic = true;
        volumeSlider.value = AudioManager.instance.MusicVolume;
    }

    public void SwitchToSFX()
    {
        controllingMusic = false;
        volumeSlider.value = AudioManager.instance.SfxVolume;
    }

    void OnSliderValueChanged(float value)
    {
        if (controllingMusic)
            AudioManager.instance.SetMusicVolume(value);
        else
            AudioManager.instance.SetSFXVolume(value);
    }
}
