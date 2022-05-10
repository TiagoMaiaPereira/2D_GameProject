using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicAir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Oxygen>().EnterZone();
            other.GetComponent<Oxygen>().speedToSlow = 2f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Oxygen>().LeaveZone();
        }
    }
}
