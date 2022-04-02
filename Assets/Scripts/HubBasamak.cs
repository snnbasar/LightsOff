using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubBasamak : MonoBehaviour
{
    public static HubBasamak instance;

    [SerializeField]
    private int animNumarasi;
    [SerializeField]
    private float animCoolDown = 0.1f;
    [SerializeField] ParticulEffectController particulEffect; //Set on Inspector.

    private List<Basamak> basamaklar = new List<Basamak>();


    private void Awake()
    {
        instance = this;
        UpdateBasamakList();
        BaslangicAnim.instance.onBaslangicAnimStart += StartAnimation;
    }
    void Start()
    {
        SetParticulEffectPlayMode(false);
        
    }

    public void OnGameRestarted()
    {
        foreach (Basamak basamak in basamaklar)
        {
            basamak.OnGameRestarted();
        }


    }

    public void StartAnimation()
    {
        StartCoroutine("StartAnimCo");
    }

    private IEnumerator StartAnimCo()
    {
        Vector3 startPosition = basamaklar[0].transform.position;
        SetParticulEffectStartPosition(startPosition);
        SetParticulEffectPlayMode(true);


        foreach (Basamak basamak in basamaklar)
        {
            SetParticulEffectDestination(basamak.transform.position, animCoolDown);
            yield return new WaitForSeconds(animCoolDown);
            basamak.StartAnimation(animNumarasi, animCoolDown);
        }

        SetParticulEffectPlayMode(false);
        yield return new WaitForSeconds(1f);
        SetParticulEffectPlayMode(false);
        StartCoroutine("StopAnimCo");
        StopCoroutine("StartAnimCo");
    }


    private IEnumerator StopAnimCo()
    {
        Vector3 startPosition = basamaklar[0].transform.position;
        SetParticulEffectStartPosition(startPosition);
        SetParticulEffectPlayMode(true);


        foreach (Basamak basamak in basamaklar)
        {
            SetParticulEffectDestination(basamak.transform.position, animCoolDown);
            yield return new WaitForSeconds(animCoolDown);
            basamak.StopAnimation(animNumarasi, animCoolDown);
        }


        SetParticulEffectPlayMode(false);
        yield return new WaitForSeconds(1f);
        BaslangicAnim.instance.BaslangicAnimEnd();
        StopCoroutine("StopAnimCo");
    }

    private void UpdateBasamakList()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).TryGetComponent<Basamak>(out Basamak basamak))
                basamaklar.Add(basamak);
        }
        
    }

    #region SetParticulEffectProperties
    private void SetParticulEffectPlayMode(bool mode)
    {
        particulEffect.SetEnabled(mode);
    }

    private void SetParticulEffectStartPosition(Vector3 pos)
    {
        particulEffect.ResetPosTo(pos);
    }

    private void SetParticulEffectDestination(Vector3 dest, float time)
    {
        particulEffect.GoToPosition(dest, time);
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
