using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HealthSystem : MonoBehaviour
{
    [Header("Hearts Setup")]
    public int maxHearts = 5;
    public int healthPerHeart = 2;
    public int CurrentHealth { get; private set; }
    public int MaxHealth => maxHearts * healthPerHeart;

    public event Action<int, int> onHealthChanged;

    void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void Damage(int amount)
    {
        if (amount <= 0) return;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        onHealthChanged?.Invoke(CurrentHealth, MaxHealth);

        if (CurrentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0) return;
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        onHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    public void SetMaxHearts(int newMaxHearts, bool refill = true)
    {
        maxHearts = Mathf.Max(1, newMaxHearts);
        if (refill) CurrentHealth = MaxHealth;
        CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);
        onHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }
}
