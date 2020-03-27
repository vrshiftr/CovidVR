﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdowntimerminus : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 10;
    public bool takingAway = false;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "0:" + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
}
    IEnumerator TimerTake()
    {
       takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = "0:" + secondsLeft;
       takingAway = false;
    }
}