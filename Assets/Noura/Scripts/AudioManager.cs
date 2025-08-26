using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager I;

    [Header("Mixer")]
    public AudioMixer mixer;  
   
    public string musicParam = "MusicVolume";
    public string sfxParam = "SFXVolume";

    [Header("Defaults (0..1)")]
    [Range(0f, 1f)] public float defaultMusic = 0.8f;
    [Range(0f, 1f)] public float defaultSFX = 0.8f;

    const string PP_MUSIC = "PP_MusicVol";
    const string PP_SFX = "PP_SFXVol";

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);

        float m = PlayerPrefs.HasKey(PP_MUSIC) ? PlayerPrefs.GetFloat(PP_MUSIC) : defaultMusic;
        float s = PlayerPrefs.HasKey(PP_SFX) ? PlayerPrefs.GetFloat(PP_SFX) : defaultSFX;

        SetMusic(m);
        SetSFX(s);
    }

    public void SetMusic(float v)
    {
        
        float dB = (v <= 0.0001f) ? -80f : Mathf.Log10(v) * 20f;
        mixer.SetFloat(musicParam, dB);
        PlayerPrefs.SetFloat(PP_MUSIC, v);
    }

    public void SetSFX(float v)
    {
        float dB = (v <= 0.0001f) ? -80f : Mathf.Log10(v) * 20f;
        mixer.SetFloat(sfxParam, dB);
        PlayerPrefs.SetFloat(PP_SFX, v);
    }

    public float GetMusic01()
    {
        return PlayerPrefs.HasKey(PP_MUSIC) ? PlayerPrefs.GetFloat(PP_MUSIC) : defaultMusic;
    }

    public float GetSFX01()
    {
        return PlayerPrefs.HasKey(PP_SFX) ? PlayerPrefs.GetFloat(PP_SFX) : defaultSFX;
    }
}