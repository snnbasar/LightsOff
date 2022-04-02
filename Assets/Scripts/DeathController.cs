using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public ParticleSystem deathParticle; //sets on inspector
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.RestartGame();
            deathParticle.Play();
        }
    }
}
