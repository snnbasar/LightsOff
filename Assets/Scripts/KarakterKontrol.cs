using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharacterState
{
    BaslangicAnim,
    Hareket
}
public class KarakterKontrol : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    private float hor;
    private float ver;
    private Vector3 movement;

    private Rigidbody rg;
    private Animator anim;

    private CharacterState characterState;

    // Start is called before the first frame update
    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();
        characterState = CharacterState.BaslangicAnim;
        BaslangicAnim.instance.onBaslangicAnimEnd += SwitchCharacterStateToHareket;
        SetAnimOnPlatform(false);
    }

    public void SwitchCharacterStateToHareket()
    {
        characterState = CharacterState.Hareket;
    }

    public void SwitchCharacterStateToBaslangicAnim()
    {
        characterState = CharacterState.BaslangicAnim;
    }

    private void SwitchCharacterState(CharacterState state)
    {
        characterState = state;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (characterState)
        {
            case CharacterState.BaslangicAnim:
                //doAnimasyon
                ResetAnimationOnCharacter();
                break;
            case CharacterState.Hareket:
                Movement();
                break;
            default:
                break;
        }



    }


    private void Movement()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        anim.SetFloat("ver", ver);
        anim.SetFloat("hor", hor);

        movement = new Vector3(hor, 0, ver);

        movement = transform.TransformDirection(movement);
        

        rg.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }



    public void SetAnimOnPlatform(bool platform)
    {
        anim.SetBool("onPlatform", platform);
    }

    private void ResetAnimationOnCharacter()
    {
        anim.SetFloat("ver", 0f);
        anim.SetFloat("hor", 0f);
    }
}
