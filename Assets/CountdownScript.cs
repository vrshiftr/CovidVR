
    using UnityEngine;
using System.Collections.Generic;
using System.Collections;
    
    using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
    {
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public GameObject timerobj;
    public GameObject gameovr;

    void Start()

    {
        timer = mainTimer;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("00");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "00";
            timer = 0.0f;
            GameOver();
        }
    }

    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
         
        }


void GameOver()
    {
        if (SumScore.Score > SumScore.HighScore)
            SumScore.SaveHighScore();
        SumScore.Reset();
        timerobj.SetActive(false);
        gameovr.SetActive(true);
        
    }
}



