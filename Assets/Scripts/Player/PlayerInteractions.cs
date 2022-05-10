using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private IInteractable interactable = null;


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
}
