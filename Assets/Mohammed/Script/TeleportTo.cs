using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    public GameObject spot;
    public GameObject Player;
    public CanvasGroup Fadding;

    // private bool FadeIn;
    // private bool FadeOut;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // FadeIn = true;
            StartCoroutine(FadDuration());
            Player.transform.position = spot.transform.position;
        }
    }
    IEnumerator FadDuration()
    {
        Fadding.alpha = 1;
        yield return new WaitForSeconds(0.5f);
        Fadding.alpha = 0;






    // Junk code // // Junk code // // Junk code //




        // Fadding.alpha = 1;
        // if (FadeIn == true)
        // {
        // DoFadeIn();            
        // }

        // if (FadeIn == false)
        // {
        //     yield return new WaitForSeconds(1);
        //     DoFadeOut();
        //     }


        // Fadding.alpha = 0;

    }
    // public void DoFadeIn()
    // {
    //     if (FadeIn == true)
    //     {
    //         if (Fadding.alpha < 1)
    //         {
    //             Fadding.alpha += Time.deltaTime;
    //             if (Fadding.alpha >= 1)
    //             {
    //                 FadeIn = false;
    //                 FadeOut = true;
    //             }
    //         }
    //     }
    // }
    // public void DoFadeOut()
    // {
    // if (FadeOut == true)
    //     {
    //         if (Fadding.alpha >= 0)
    //         {
    //             Fadding.alpha -= Time.deltaTime;
    //             if (Fadding.alpha == 0)
    //             {
    //                 FadeOut = false;
    //             }
    //         }
    //     }
    // }
}
