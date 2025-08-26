using UnityEngine;

public class Playerinteractions : MonoBehaviour
{
    Animator anim;
    public AudioSource backgroundmusic;
    public AudioSource ad;
    public AudioClip cloud;
    public AudioClip Jmup;
    public AudioClip Damage;
    public SkinnedMeshRenderer mr;
    

    Color origcolor;
    float flashTime = .15f;

    Rigidbody rb;

    [Header("Jump Settings")]
    public float jumpForce = 7f;
    bool isGrounded = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
        mr = GetComponent<SkinnedMeshRenderer>();
        rb = GetComponent<Rigidbody>();

        origcolor = mr.material.color;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
       
    }

    void Jump()
    {      
        ad.PlayOneShot(Jmup);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("JumpPlatform"))
        {
            isGrounded = true;

            if (collision.gameObject.CompareTag("JumpPlatform"))
            {
                anim.SetTrigger("Jump");
                ad.PlayOneShot(cloud);
                
            }
        }

        if (collision.gameObject.CompareTag("Enem"))
        {
            flashstart();
            Debug.Log("damage");
            ad.PlayOneShot(Damage);
        }
    }

    void flashstart()
    {
        mr.material.color = Color.red;
        Invoke("Flashend", flashTime);
    }

    void Flashend()
    {
        mr.material.color = origcolor;
    }
}
