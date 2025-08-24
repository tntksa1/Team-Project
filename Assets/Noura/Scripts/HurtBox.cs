using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public HealthSystem health;   
    public float iFrames = 0.5f;  
    float lastHit = -999f;

    public bool Damage(int amount)
    {
        if (!health) return false;
        if (Time.time - lastHit < iFrames) return false; // مناعة مؤقتة
        lastHit = Time.time;
        health.Damage(amount);
        return true;
    }
}
