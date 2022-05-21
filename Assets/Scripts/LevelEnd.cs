using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private Canvas congratsScreen = null;

    [SerializeField]
    private UnityEvent OnEnd;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnd.Invoke();
        congratsScreen.gameObject.SetActive(true);
    }
}
