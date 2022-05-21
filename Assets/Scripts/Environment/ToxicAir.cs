using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicAir : MonoBehaviour
{
    [SerializeField]
    private float time;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Breathing>().EnterToxicCloud(time);
            other.GetComponent<Breathing>().DisplayBar();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Breathing>().ExitToxicCloud();
    }


}
