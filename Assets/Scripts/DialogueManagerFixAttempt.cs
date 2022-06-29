using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerFixAttempt : MonoBehaviour
{
    public GameObject activePlayer;

    /*private void Awake()
    { 
        activePlayer = GameObject.FindGameObjectWithTag("Player");
    }*/

    private void Update()
    {
        activePlayer = GameObject.FindGameObjectWithTag("Player");

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
