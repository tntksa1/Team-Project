
using UnityEngine;

public class MonsterCopy : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float speed;
    public Animator ainm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(a);
        ainm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
    }
}
