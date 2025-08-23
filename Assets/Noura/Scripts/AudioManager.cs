using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public float MusicVolume { get; private set; } = 0.8f;
    public float SfxVolume { get; private set; } = 1f;

    const string MUSIC_KEY = "musicVol";
    const string SFX_KEY = "sfxVol";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadVolumes();
            ApplyVolumes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadVolumes()
    {
        MusicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, MusicVolume);
        SfxVolume = PlayerPrefs.GetFloat(SFX_KEY, SfxVolume);
    }

    void ApplyVolumes()
    {
        if (musicSource) musicSource.volume = MusicVolume;
        if (sfxSource) sfxSource.volume = SfxVolume;
    }

    public void SetMusicVolume(float v)
    {
        MusicVolume = Mathf.Clamp01(v);
        if (musicSource) musicSource.volume = MusicVolume;
        PlayerPrefs.SetFloat(MUSIC_KEY, MusicVolume);
    }

    public void SetSFXVolume(float v)
    {
        SfxVolume = Mathf.Clamp01(v);
        if (sfxSource) sfxSource.volume = SfxVolume;
        PlayerPrefs.SetFloat(SFX_KEY, SfxVolume);
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (!musicSource || !clip) return;
        musicSource.loop = loop;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (!sfxSource || !clip) return;
        sfxSource.PlayOneShot(clip, SfxVolume);
    }
}
