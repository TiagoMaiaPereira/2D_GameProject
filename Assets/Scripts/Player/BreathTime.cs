using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BreathTime : MonoBehaviour
{

    [SerializeField]
    private Image oxygenMeter = null;

    private float breathTime;

    private float inicialTime;

    [SerializeField]
    private TMP_Text timer = null;

    private bool inAir = false;


    private void Update()
    {
        if (inAir)
        {
            breathTime -= Time.deltaTime;
            //UpdateBar();

            if (breathTime <= 0f)
            {
                breathTime = 0f;
            }
        }
        else
        {
            breathTime = inicialTime;
        }

        timer.text = Mathf.Round(breathTime).ToString();
    }

    /*private void UpdateBar()
    {
        oxygenMeter.fillAmount = breathTime;
    }*/

    public void RedeuceTimer()
    {
        inAir = true;
    }

    public void RaiseTimer()
    {
        inAir = false;
    }

    public void GiveTime(float time)
    {
        inicialTime = time;
    }
}
