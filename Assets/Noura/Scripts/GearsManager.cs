using UnityEngine;
using UnityEngine.SceneManagement;

public class GearsManager : MonoBehaviour
{
    public static GearsManager I;

    [Header("Goal")]
    public int totalGoal = 6;

    [Header("Live")]
    public int totalCollected = 0;

    [SerializeField] string winSceneName = "WinScene";

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
    }

    public void CollectOne()
    {
        totalCollected = Mathf.Clamp(totalCollected + 1, 0, totalGoal);

        
        GearUI.RefreshStatic?.Invoke(totalCollected, totalGoal);

       
        if (totalCollected >= totalGoal)
        {
            SceneManager.LoadScene(winSceneName);
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Gear"))
        {
            CollectOne();
            Destroy(other.gameObject);
        }
    }
}
