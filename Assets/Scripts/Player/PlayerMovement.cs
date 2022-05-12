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


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        walkSpeed = startingWalkSpeed;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(horizontalInput * walkSpeed, playerRigidbody.velocity.y);


        print(walkSpeed);
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
