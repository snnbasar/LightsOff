using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulEffectController : MonoBehaviour
{
    [SerializeField] private float yOffset = 2f;
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void GoToPosition(Vector3 whereTo, float goTime)
    {
        LeanTween.move(this.gameObject, whereTo + (Vector3.up * yOffset), goTime);//.setEase(LeanTweenType.easeInOutSine)
    }

    public void SetEnabled(bool mode)
    {
        if (mode == true)
            particle.Play();
        else
            particle.Stop();
    }

    public void ResetPosTo(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

}