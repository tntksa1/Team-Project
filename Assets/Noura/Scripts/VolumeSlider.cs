using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string exposedParameter = "SFXVolume";
    public Slider slider;
    const string PPKeyPrefix = "PP_Vol_";

    void Reset() { slider = GetComponent<Slider>(); }

    void Start()
    {
        if (!slider) slider = GetComponent<Slider>();
        slider.minValue = 0f; slider.maxValue = 1f;

        string key = PPKeyPrefix + exposedParameter;
        float v = PlayerPrefs.HasKey(key) ? PlayerPrefs.GetFloat(key) : 1f;
        slider.SetValueWithoutNotify(v);   
        Apply(v);
       
    }

    
    public void Apply(float v)
    {
        float dB = (v <= 0.0001f) ? -80f : Mathf.Log10(Mathf.Clamp01(v)) * 20f;
        mixer.SetFloat(exposedParameter, dB);
        PlayerPrefs.SetFloat(PPKeyPrefix + exposedParameter, v);
    }
}
