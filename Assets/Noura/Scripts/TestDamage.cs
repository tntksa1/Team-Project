using UnityEngine;

public class TestDamage : MonoBehaviour
{
    public HealthSystem health;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) health?.Damage(1); // ينقص نصف قلب إذا healthPerHeart=2
        if (Input.GetKeyDown(KeyCode.J)) health?.Heal(1);   // يزيد
    }
}

