using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallSpeed = 2f;    
    public float delay = 0.2f;      
    public float respawnDelay = 10f; // how long before it starts coming back
    public float returnTime = 10f;  // how many seconds to return

    private bool isFalling = false;
    private bool isReturning = false;

    private Vector3 startPos;
    private Vector3 fallPos;

    void Start()
    {
        // save the platform's original position
        startPos = transform.position;
    }

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
        isReturning = false;
        CancelInvoke("StartReturning");
        Invoke("StartReturning", respawnDelay);
    }

    void StartReturning()
    {
        isFalling = false;
        isReturning = true;

        // remember where it starts returning from
        fallPos = transform.position;
    }

    void Update()
    {
        if (isFalling)
        {
            // move down
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
        else if (isReturning)
        {
            // smooth return over "returnTime"
            float t = (Time.deltaTime / returnTime);
            transform.position = Vector3.Lerp(transform.position, startPos, t);

            // stop when it's close enough
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                transform.position = startPos;
                isReturning = false;
            }
        }
    }
}
