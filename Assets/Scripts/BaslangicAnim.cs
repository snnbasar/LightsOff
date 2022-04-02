using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaslangicAnim : MonoBehaviour
{
    public static BaslangicAnim instance;

    public event Action onBaslangicAnimStart;
    public event Action onBaslangicAnimEnd;


    public GameObject lights; //Declared on Inspector


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        onBaslangicAnimStart += SetLightsOn;
        onBaslangicAnimEnd += SetLightsOff;
    }

    
    public void BaslangicAnimStart()
    {
        onBaslangicAnimStart?.Invoke();
    }

    public void BaslangicAnimEnd()
    {
        onBaslangicAnimEnd?.Invoke();
    }





    public void SetLightsOff()
    {
        TurnLights(false);
    }

    public void SetLightsOn()
    {
        TurnLights(true);
    }

    private void TurnLights(bool state)
    {
        lights.SetActive(state);
    }

}
