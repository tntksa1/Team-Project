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
    
    




    void Start()
    {
        anim = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
        mr = GetComponent<SkinnedMeshRenderer>();
        origcolor = mr.material.color;
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

        if (collision.gameObject.CompareTag("Enem"))
        {
            flashstart();
            Debug.Log("damge");
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

