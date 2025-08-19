using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    public GameObject spot;
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.transform.position = spot.transform.position;
        }
    }
}
