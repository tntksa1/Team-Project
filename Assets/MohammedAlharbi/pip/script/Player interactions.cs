using UnityEngine;

public class Playerinteractions : MonoBehaviour
{
    Animator anim;
    public AudioSource backgroundmusic;
    public AudioSource ad;
    public AudioClip  cloud;
    public AudioClip Jmup;
    public Animator monster;



    void Start()
    {
        anim = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
        monster = GetComponent<Animator>();
        
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
