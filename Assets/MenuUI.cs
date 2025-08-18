using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelMain;
    public GameObject panelAudio;

    [Header("Main Buttons")]
    public Button btnPlay;
    public Button btnOptions;
    public Button btnExit;

    [Header("Audio Buttons")]
    public Button btnMusic;
    public Button btnSFX;
    public Button btnBack;

    void Awake()
    {
        // الحالة الأولى: نعرض الرئيسية
        ShowMain(true);

        // ربط الأزرار
        btnPlay.onClick.AddListener(OnPlay);
        btnOptions.onClick.AddListener(() => ShowMain(false));
        btnExit.onClick.AddListener(OnExit);

        btnMusic.onClick.AddListener(() => Debug.Log("Music clicked"));
        btnSFX.onClick.AddListener(() => Debug.Log("SFX clicked"));
        btnBack.onClick.AddListener(() => ShowMain(true));
    }

    void ShowMain(bool showMain)
    {
        panelMain.SetActive(showMain);
        panelAudio.SetActive(!showMain);
    }

    void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

