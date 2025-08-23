using UnityEngine;

public class WinUI : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        Debug.Log("Quit from Win Scene (Editor)");
#endif
    }
}

