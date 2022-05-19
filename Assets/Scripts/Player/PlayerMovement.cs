using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //References
    private Rigidbody2D playerRigidbody;
    

    //Variables
    [SerializeField]
    private float walkSpeed = 2f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(horizontalInput * walkSpeed, playerRigidbody.velocity.y);

    }
}
