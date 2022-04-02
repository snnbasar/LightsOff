using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Basamak : MonoBehaviour
{

    private Material mat;

    private MeshRenderer mRenderer;

    private bool lightInfo;

    [SerializeField]
    private static float blinkTime = 0.2f;

    private IEnumerator basamakBlink;
    private IEnumerator basamakAnim;

    // Start is called before the first frame update
    void Start()
    {
        mRenderer = this.GetComponent<MeshRenderer>();
        mat = Resources.Load("emis") as Material;
        mRenderer.material = new Material(mat);
        SetEmission(false);

    }

    public void OnGameRestarted()
    {
        SetEmission(false);
    }

    private void LightInfo(bool lightInfo)
    {
        this.lightInfo = lightInfo;
    }
    
    private void SetEmission(bool em)
    {
        if (em == true)
        {
            mRenderer.material.EnableKeyword("_EMISSION");
            LightInfo(true);
            SoundManager.instance.PlayBasamakStepAudio();
        }
        if (em == false)
        {
            mRenderer.material.DisableKeyword("_EMISSION");
            LightInfo(false);
        }
    }

    private bool IsEmissionTrue
    {
        get
        {
            return lightInfo;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            //SetCharacterAnimOnPlatform(collision.gameObject, true);
            if (IsEmissionTrue)
            {
                basamakBlink = BasamakBlink(blinkTime);
                StartCoroutine(basamakBlink);
            }
            else
                SetEmission(true);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //SetCharacterAnimOnPlatform(collision.gameObject, false);
        }
    }

    private void SetCharacterAnimOnPlatform(GameObject player, bool platform)
    {
        player.GetComponent<KarakterKontrol>().SetAnimOnPlatform(platform);
    }


    private IEnumerator BasamakBlink(float waitTime)
    {
        SetEmission(false);
        yield return new WaitForSeconds(waitTime);
        SetEmission(true);
        StopCoroutine("BasamakBlink");
    }

    private IEnumerator BasamakAnim(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetEmission(true);
        yield return new WaitForSeconds(waitTime * 3);
        SetEmission(false);
        StopCoroutine("BasamakAnim");
    }


    public void StartAnimation(int anim, float cooldown)
    {
        if (anim == 0)
        {
            SetEmission(true);
        }

        if (anim == 1)
        {
            basamakAnim = BasamakAnim(cooldown);
            StartCoroutine(basamakAnim);
        }
    }

    public void StopAnimation(int anim, float cooldown)
    {
        if (anim == 0)
        {
            SetEmission(false);
            SoundManager.instance.PlayBasamakStepAudio();//
        }
        if (anim == 1)
        {
            return;
        }
    }
}
