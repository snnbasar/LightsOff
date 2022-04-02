using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private Text countDownText;

    public bool animStart;

    public int countDown = 3;
    // Start is called before the first frame update
    private void Start()
    {
        countDownText = transform.GetComponentInChildren<Text>();
        GameManager.instance.onStartGame += StartAnimStart;
    }


    float delta;
    int tamSayi;
    private void Sayac()
    {

        if (tamSayi < 55)
        {
            delta += Time.deltaTime * 50;
            tamSayi = (int)delta;
            countDownText.fontSize = tamSayi;
        }
        else
        {
            delta = 0;
            tamSayi = 0;
            ResetNumberTo(countDown - 1);
        }
    }
    void Update()
    {
        if (animStart == true)
        {

            switch (countDown)
            {
                case 3:
                    Sayac();
                    break;
                case 2:
                    Sayac();
                    break;
                case 1:
                    Sayac();
                    break;
                case 0:
                    BaslangicAnim.instance.BaslangicAnimStart();
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        }
    }

    private void ResetNumberTo(int number)
    {
        countDownText.text = number.ToString();
        countDownText.fontSize = 1;
        countDown = number;
    }



    private void StartAnimStart()
    {
        animStart = true;
    }
}
