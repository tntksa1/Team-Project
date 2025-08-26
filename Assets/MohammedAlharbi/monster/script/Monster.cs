
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float speed;
    public Animator ainm;
    Rigidbody rb;
    public Collider co;
    AudioSource ad;
    public Collider hit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(a);
        ainm = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ad = GetComponent<AudioSource>();
        co = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("a"))
        {
            transform.LookAt(b);
        }
        else if (other.gameObject.CompareTag("b"))
        {
            transform.LookAt(a);
        }
        if (other.gameObject.CompareTag("foot"))
        {

            rb.isKinematic = true;
            co.enabled = false;
            ad.Play();
            ainm.SetBool("Death", true);
            speed = 0;
            Debug.Log("Death");
            hit.enabled = false;
            
            
            
        }

    }
    
    
        
    
}
