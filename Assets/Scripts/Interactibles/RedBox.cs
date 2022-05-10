using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class RedBox: MonoBehaviour, IInteractable
{
    [SerializeField]
    private Image interactPrompt = null;

    [SerializeField]
    private TMP_Text interactionText = null;

    [SerializeField]
    private float timeToRead;

    [SerializeField]
    private UnityEvent OnInteract;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.gameObject.SetActive(true);
            other.GetComponent<PlayerInteractions>().SetInteractible(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.gameObject.SetActive(false);
            other.GetComponent<PlayerInteractions>().SetInteractible(null);
        }
    }

    public void Interact()
    {
        interactPrompt.gameObject.SetActive(false);
        interactionText.text = "I found a key...";
        interactionText.gameObject.SetActive(true);
        OnInteract.Invoke();
        Invoke(nameof(DismissText), timeToRead);
        gameObject.SetActive(false);
        Destroy(gameObject, timeToRead);
    }

    private void DismissText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
