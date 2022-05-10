using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackBox : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Image interactPrompt = null;

    [SerializeField]
    private TMP_Text interactionText = null;

    [SerializeField]
    private float timeToRead;

    private bool hasKey = false;

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
        if (!hasKey)
        {
            interactPrompt.gameObject.SetActive(false);
            interactionText.text = "I need a key";
            interactionText.gameObject.SetActive(true);
            Invoke(nameof(DismissText), timeToRead);
        }
        else
        {
            interactPrompt.gameObject.SetActive(false);
            interactionText.text = "I unlocked it!";
            interactionText.gameObject.SetActive(true);
            Invoke(nameof(DismissText), timeToRead);
            gameObject.SetActive(false);
            Destroy(gameObject, timeToRead);
        }
    }

    private void DismissText()
    {
        interactionText.gameObject.SetActive(false);
    }

    public void GotKey()
    {
        hasKey = true;
    }
}
