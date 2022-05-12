using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    //


    //Variables

    [SerializeField]
    private float maxOxygen = 100;

    private float oxygen;

    [SerializeField]
    private Image oxygenBar = null;

    [SerializeField]
    private float waitForSeconds;

    [SerializeField]
    private float ammountToDecrease;

    public float speedToSlow;

    //Coroutine decreaseOxygen;

    //Coroutine increaseOxygen;

    private WaitForSeconds timeToCheckBar;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        oxygen = maxOxygen;
        UpdateBar();
        timeToCheckBar = new WaitForSeconds(waitForSeconds);
    }

    private void UpdateBar()
    {
        oxygenBar.fillAmount = oxygen / maxOxygen;
    }

    private IEnumerator OxygenDecrease()
    {
        while (oxygen > 0)
        {
            yield return timeToCheckBar;

            oxygen -= ammountToDecrease;
            if (oxygen < 0)
            {
                oxygen = 0;
            }
            UpdateBar();
            if(oxygen == 0)
            {
               yield break;
            }
        }
    }

    private IEnumerator OxygenIncrease()
    {
        while(oxygen < maxOxygen)
        {
            yield return timeToCheckBar;
            oxygen += ammountToDecrease;
            if(oxygen > maxOxygen)
            {
                oxygen = maxOxygen;
            }
            UpdateBar();
            if (oxygen == maxOxygen)
            {
               yield break;
            }
        }
    }

    public void EnterZone()
    {
        StopAllCoroutines();
        StartCoroutine(OxygenDecrease());
        playerMovement.SlowDownCharacter(speedToSlow);
    }

    public void LeaveZone()
    {
        StopAllCoroutines();
        StartCoroutine(OxygenIncrease());
        playerMovement.ReturnSpeed();
    }
}
