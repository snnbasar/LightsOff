using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerOnPlatform : MonoBehaviour
{
    public KarakterKontrol playerKarakterKontrol;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerKarakterKontrol.SetAnimOnPlatform(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerKarakterKontrol.SetAnimOnPlatform(false);
        }
    }
}
