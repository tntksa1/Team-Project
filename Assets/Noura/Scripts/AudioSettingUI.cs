using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        if (AudioManager.instance)
        {
            musicSlider.value = AudioManager.instance.MusicVolume;
            sfxSlider.value = AudioManager.instance.SfxVolume;
        }
    }
}
