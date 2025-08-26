using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SimpleCutscene : MonoBehaviour
{
    public VideoPlayer player;
    public string nextScene = "MainMenu";

    void Start()
    {
        if (!player) player = GetComponent<VideoPlayer>();
        player.playOnAwake = false;
        player.waitForFirstFrame = true;
        player.skipOnDrop = false;

        player.prepareCompleted += Prepared;
        player.loopPointReached += EndReached;

        player.Prepare();
    }

    void Prepared(VideoPlayer vp)
    {
        player.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(nextScene);
    }
}
