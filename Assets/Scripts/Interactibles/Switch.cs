using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject lightToLink = null;


    private IActivable linkedLight = null;


    private void Awake()
    {
        linkedLight = lightToLink.GetComponent<IActivable>();    
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
        linkedLight.Activate();
    }
}
