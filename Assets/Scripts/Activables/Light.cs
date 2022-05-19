using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour, IActivable
{
    private SpriteRenderer sprite = null;

    [SerializeField]
    private Elevator linkedElevator;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Activate()
    {
        sprite.color = Color.green;
        linkedElevator.AddLight();
    }

    
}
