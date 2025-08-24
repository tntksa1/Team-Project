using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HealthSystem : MonoBehaviour
{
    [Header("Hearts")]
    public int maxHearts = 5;        // كم قلب
    public int healthPerHeart = 2;   // كم نقطة داخل كل قلب

    public int MaxHealth => maxHearts * healthPerHeart;
    public int CurrentHealth { get; private set; }

    
    public event Action<int, int> onHealthChanged;

    void Awake()
    {
        CurrentHealth = MaxHealth;
        onHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    public void Damage(int amount)
    {
        if (amount <= 0) return;

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        onHealthChanged?.Invoke(CurrentHealth, MaxHealth);

        if (CurrentHealth == 0)
            GoGameOver();
    }

    public void Heal(int amount)
    {
        if (amount <= 0) return;

        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        onHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    void GoGameOver()
    {
       
        SceneManager.LoadScene("GameOver");
       
    }
}
