using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneEnd : MonoBehaviour
{
    public PlayableDirector director;
    public string nextScene = "MainMenu";

    void Awake()
    {
        if (!director) director = GetComponent<PlayableDirector>();
        director.stopped += OnStopped;
    }

    void OnStopped(PlayableDirector d)
    {
        SceneManager.LoadScene(nextScene);
    }
}
