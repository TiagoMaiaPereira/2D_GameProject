using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Elevator : MonoBehaviour, IActivable, IInteractable
{
    [SerializeField]
    private List<Transform> points = new List<Transform>();

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private int targetIndex = 1;
    private float startTime = 0f;

    [SerializeField]
    private int lightsOn = 0;

    [SerializeField]
    private int maxLights = 0;

    [SerializeField]
    private float duration = 5f;

    private bool canMove = false;
    private bool canInteract = false;

    [SerializeField]
    private UnityEvent OnMove;

    [SerializeField]
    private UnityEvent OnStop;

    private void Awake()
    {
        startPosition = points[0].position;
        targetPosition = points[targetIndex].position;
    }


    private void Update()
    {
        if (canMove)
        {
            float t = (Time.time - startTime) / duration;

            transform.position = new Vector3
                (Mathf.SmoothStep(startPosition.x,
                targetPosition.x, t),
                Mathf.SmoothStep(startPosition.y, targetPosition.y, t)
                , transform.position.z);

            if (t >= 1)
            {
                StopMoving();
                SwitchPosition();
                OnStop.Invoke();
            }
        }
        
        if(lightsOn == maxLights)
        {
            Activate();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (canInteract)
            {
                other.GetComponent<PlayerInteractions>().DisplayPrompt();
                other.GetComponent<PlayerInteractions>().SetInteractible(this);
                other.GetComponent<Transform>().SetParent(this.gameObject.transform);
                print("Entered Trigger");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (canInteract)
        {
            other.GetComponent<PlayerInteractions>().HidePrompt();
            other.GetComponent<PlayerInteractions>().SetInteractible(null);
            other.GetComponent<Transform>().SetParent(null);
        }
    }



    private void SwitchPosition()
    {
        startPosition = targetPosition;
        targetIndex = (targetIndex + 1) % points.Count;
        targetPosition = points[targetIndex].position;
    }

    private void StopMoving()
    {
        canMove = false;
    }

    public void Interact()
    {
        OnMove.Invoke();
        startTime = Time.time;
        canMove = true;

        print("Interact");
    }

    public void Activate()
    {
        canInteract = true;
    }

    public void AddLight()
    {
        lightsOn++;
    }

}
