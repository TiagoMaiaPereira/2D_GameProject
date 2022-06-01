using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [SerializeField]
    private DialogueScriptableObject dialogue;

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
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
