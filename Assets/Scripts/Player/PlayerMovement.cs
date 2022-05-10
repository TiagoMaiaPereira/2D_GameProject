using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //References

    private Rigidbody2D playerRigidbody;
    

    //Variables
    
    private float walkSpeed;

    [SerializeField]
    private float startingWalkSpeed = 2f;

    //Bool
    private bool canClimb = false;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        walkSpeed = startingWalkSpeed;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (!canClimb)
        {
            playerRigidbody.velocity = new Vector2(horizontalInput * walkSpeed, playerRigidbody.velocity.y);
        }

        if (canClimb)
        {
            playerRigidbody.velocity = new Vector2(horizontalInput * walkSpeed, verticalInput * walkSpeed);
        }

        print(walkSpeed);
    }

    public void AllowClimb()
    {
        canClimb = true;
    }

    public void NoClimb()
    {
        canClimb = false;
    }

    public void SlowDownCharacter(float slowSpeed)
    {
        walkSpeed = walkSpeed / slowSpeed;
    }

    public void ReturnSpeed()
    {
        walkSpeed = startingWalkSpeed;
    }
}
