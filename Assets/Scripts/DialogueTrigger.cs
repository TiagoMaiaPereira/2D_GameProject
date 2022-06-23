using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [SerializeField]
    private DialogueScriptableObject dialogue;

    private bool inDialogue;

    private bool dialogueEnd;

    [SerializeField]
    private Image textPanel;

    [SerializeField]
    private UnityEvent OnStartDialogue;

    [SerializeField]
    private UnityEvent OnEndDialogue;

    private void Update()
    {
        inDialogue = DialogueManager.Instance.inDialogue;
        dialogueEnd = DialogueManager.Instance.dialogueEnded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteractions>().SetInteractible(this);
            other.GetComponent<PlayerInteractions>().DisplayPrompt();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteractions>().SetInteractible(null);
            other.GetComponent<PlayerInteractions>().HidePrompt();
        }
    }

    public void Interact()
    {
        if (inDialogue)
        {
            print("In Dialogue...");
            DialogueManager.Instance.DisplayNextSentence();
        }
        else
        {
            DialogueManager.Instance.StartDialogue(dialogue);
            OnStartDialogue.Invoke();
        }

        if (dialogueEnd)
        {
            OnEndDialogue.Invoke();
        }

    }
}
