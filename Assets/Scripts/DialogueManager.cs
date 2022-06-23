using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; } = null;

    private Queue<string> sentences;

    [SerializeField]
    private TMP_Text characterName;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private GameObject dialoguePanel = null;

    public bool inDialogue { get; private set; } = false;

    public bool dialogueEnded { get; set; } = false;

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
        dialogueEnded = false;

        characterName.text = dialogue.charName;

        dialoguePanel.SetActive(true);

        Debug.Log("Dialogue started with " + dialogue.charName);

        sentences.Clear();

        inDialogue = true;
        
        foreach(string sentence in dialogue.sentences)
        {
            ///Summary
            ///For each sentence in the scriptable object's sentences
            ///array, it will add them to the queue in order
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            print("No more sentences");
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        inDialogue = false;
        dialogueEnded = true;
        dialoguePanel.SetActive(false);
        Debug.Log("End of conversation...");
    }

}
