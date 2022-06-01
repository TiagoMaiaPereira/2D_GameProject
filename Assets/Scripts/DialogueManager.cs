using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; } = null;

    private Queue<string> sentences;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        sentences = new Queue<string>();
    }


    public void StartDialogue(DialogueScriptableObject dialogue)
    {
        Debug.Log("Dialogue started with " + dialogue.charName);
    }
}
