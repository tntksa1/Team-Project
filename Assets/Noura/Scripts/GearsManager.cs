using UnityEngine;
using UnityEngine.SceneManagement;

public class GearsManager : MonoBehaviour
{
    public static GearsManager I;

    [Header("Goals")]
    public int totalGoal = 6;
    public int levelGoal = 2;

    [Header("Live")]
    public int totalCollected = 0;
    public int levelCollected = 0;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;

        SceneManager.sceneLoaded += (_, __) => levelCollected = 0;
    }

    public void CollectOne()
    {
        totalCollected++;
        levelCollected++;
        GearUI.RefreshStatic?.Invoke(levelCollected, levelGoal, totalCollected, totalGoal);
    }

    // <<< الإضافة: جمع الكوين/الترس >>>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) // أو غيّرها إلى "Gear"
        {
            CollectOne();
            Destroy(other.gameObject);
        }
    }
    
}
