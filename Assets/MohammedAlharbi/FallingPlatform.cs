using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallSpeed = 2f;   
    public float delay = 0.2f;     

    private bool isFalling = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("StartFalling", delay);
        }
    }

    void StartFalling()
    {
        isFalling = true;
    }

    void Update()
    {
        if (isFalling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
}
