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


    private bool canMove = true;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (canMove)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            playerRigidbody.velocity = new Vector2(horizontalInput * walkSpeed, playerRigidbody.velocity.y);
        }
    }

    public void Die()
    {
        canMove = false;
        playerRigidbody.velocity = new Vector2(0f, 0f);
    }
}
