using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToxicAir : MonoBehaviour
{

    [SerializeField]
    private float inicialTime;

    [SerializeField]
    private UnityEvent OnEnter;

    [SerializeField]
    private UnityEvent OnExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BreathTime>().GiveTime(inicialTime);
            OnEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnExit.Invoke();
        }
    }


}
