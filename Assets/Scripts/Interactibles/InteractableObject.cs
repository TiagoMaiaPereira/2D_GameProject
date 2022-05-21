using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableObject : MonoBehaviour, IInteractable
{

    [SerializeField]
    private float timeToRead;

    [SerializeField]
    private Canvas dialogueBox = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteractions>().DisplayPrompt();
            other.GetComponent<PlayerInteractions>().SetInteractible(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteractions>().HidePrompt();
            other.GetComponent<PlayerInteractions>().SetInteractible(null);
        }
    }

    public void Interact()
    {
        dialogueBox.gameObject.SetActive(true);
        Invoke(nameof(DismissCanvas), timeToRead);
    }

    private void DismissCanvas()
    {
        dialogueBox.gameObject.SetActive(false);
    }
}
