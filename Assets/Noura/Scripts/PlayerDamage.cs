using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Header("Refs")]
    public HealthSystem health;

    [Header("Hit by Enemy (via Tag)")]
    public string enemyTag = "Enemy";
    public float iFrames = 0.5f;   // مناعة بعد الضربة

    [Header("Fall Kill")]
    public bool enableFallKill = true;
    public float minY = -10f;
    public int fallDamage = 999;
    public bool oneShotFall = true;

    float _lastHitTime = -999f;
    bool _fallTriggered = false;

    void Reset()
    {
        if (!health) health = GetComponentInParent<HealthSystem>() ?? GetComponent<HealthSystem>();
    }

    void Awake()
    {
        if (!health) health = GetComponentInParent<HealthSystem>() ?? GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (!enableFallKill || !health) return;

        if (transform.position.y < minY)
        {
            if (oneShotFall && _fallTriggered) return;
            _fallTriggered = true;
            TryDamage(fallDamage);                // قتل بالسقوط
        }
        else if (oneShotFall)
        {
            _fallTriggered = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(enemyTag))
            TryDamage(health ? health.healthPerHeart : 1);   // قلب كامل
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
            TryDamage(health ? health.healthPerHeart : 1);   // قلب كامل
    }

    void TryDamage(int amount)
    {
        if (!health) return;

        // مناعة بعد الضربة
        if (Time.time - _lastHitTime < iFrames) return;
        _lastHitTime = Time.time;

        health.Damage(amount);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (!enableFallKill) return;
        Gizmos.color = Color.red;
        Vector3 a = new Vector3(-1000f, minY, -1000f);
        Vector3 b = new Vector3(1000f, minY, -1000f);
        Vector3 c = new Vector3(1000f, minY, 1000f);
        Vector3 d = new Vector3(-1000f, minY, 1000f);
        Gizmos.DrawLine(a, b); Gizmos.DrawLine(b, c); Gizmos.DrawLine(c, d); Gizmos.DrawLine(d, a);
    }
#endif
}
