using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    private Text fpsText;

    private int fps;
    // Start is called before the first frame update
    void Start()
    {
        fpsText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fps = (int)(1f / Time.deltaTime);
        fpsText.text = fps.ToString();
    }
}
