using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerFixAttempt : MonoBehaviour
{
    public GameObject activePlayer;

    private void Start()
    { 
        activePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (activePlayer != null)
        {
            Debug.Log("Player Detected!");
        }


        if (activePlayer == null)
        {
            Debug.LogError("No player detected!");
        }
    }
}
