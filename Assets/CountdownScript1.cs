
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using UnityEngine.UI;

public class CountdownScript1 : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    public GameObject text1;
    public GameObject text2;
    public GameObject trigger;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;


    void Start()

    {
        timer = mainTimer;

    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            text1.SetActive(false);
            text2.SetActive(true);
            trigger.SetActive(false);
      

        }
    }

    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;

    }
}


