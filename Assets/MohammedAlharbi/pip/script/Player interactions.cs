using UnityEngine;

public class Playerinteractions : MonoBehaviour
{
    Animator anim;
    public AudioSource backgroundmusic;
    public AudioSource ad;
    public AudioClip  cloud;
    public AudioClip Jmup;



    void Start()
    {
        anim = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ad.PlayOneShot(Jmup);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpPlatform"))
        {
            anim.SetTrigger("Jump");
            ad.PlayOneShot(cloud);

        }
    }
}
