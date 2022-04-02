using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    public event Action onStartGame;


    public Transform startPosionForPlayer; //sets on inspector
    public GameObject characterObject; //sets on inspector

    public Button restartGameButton; //sets on inspector 

    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        restartGameButton.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        restartGameButton.gameObject.SetActive(true);
    }

    public void OnRestartGame()
    {
        characterObject.transform.position = startPosionForPlayer.position;
        characterObject.GetComponent<KarakterKontrol>().SwitchCharacterStateToBaslangicAnim();
        HubBasamak.instance.OnGameRestarted();
        BaslangicAnim.instance.BaslangicAnimStart();
    }

    public void StartGame()
    {
        onStartGame?.Invoke();
    }
}
