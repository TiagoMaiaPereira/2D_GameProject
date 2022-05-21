using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    private IInteractable interactable = null;

    [SerializeField]
    private Image interactPrompt = null;


    private bool canInteract = true;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            if(interactable != null)
            {
                interactable.Interact();
            }

        }
    }

    public void EnableInteraction() //the player enters the "interaction range"
    {
        canInteract = true;
    }

    public void DisableInteraction() //the player leaves the "interaction range"
    {
        canInteract = false;
    }

    public void SetInteractible(IInteractable Interactable)
    {
        this.interactable = Interactable;
    }

    public void DisplayPrompt()
    {
        interactPrompt.gameObject.SetActive(true);
    }

    public void HidePrompt()
    {
        interactPrompt.gameObject.SetActive(false);
    }
}
