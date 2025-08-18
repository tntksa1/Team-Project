using UnityEngine;

public class Playerinteractions : MonoBehaviour
{
    Animator anim;
    public AudioSource backgroundmusic;
    public AudioSource ad;
    public AudioClip  cloud;



    void Start()
    {
        anim = GetComponent<Animator>();
        cloud = GetComponent<AudioClip>();
        
    }

    void Update()
    {

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
