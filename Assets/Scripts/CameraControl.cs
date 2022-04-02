using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform character; //defined in inspector
    private CinemachineVirtualCamera cinemachineCam;


    // Start is called before the first frame update
    void Start()
    {
        cinemachineCam = GetComponent<CinemachineVirtualCamera>();
        //BaslangicAnim.instance.onBaslangicAnimEnd += SetCameraLookAtToPlayer;
        //BaslangicAnim.instance.onBaslangicAnimStart += SetCameraLookAtToNull;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCameraLookAtToPlayer()
    {
        cinemachineCam.LookAt = character;
    }

    private void SetCameraLookAtToNull()
    {
        cinemachineCam.LookAt = null;
    }
}
