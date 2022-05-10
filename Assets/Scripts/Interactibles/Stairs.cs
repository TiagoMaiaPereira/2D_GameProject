using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Stairs : MonoBehaviour
{
    [SerializeField]
    private UnityEvent InTrigger;

    [SerializeField]
    private UnityEvent OffTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            InTrigger.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 7f;
            OffTrigger.Invoke();
        }
    }

}
