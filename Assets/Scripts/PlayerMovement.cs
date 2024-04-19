using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

public float moveSpeed = 5f;

    private Rigidbody2D rb;
    public Animator playerAnimator;

    Vector2 movement;

    private void Start()
    {
        //get Rigidbody 2D
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //Get Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Sends the axis movement info to the animator
        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        //Change Position
        //movement.normalized is critical as it prevents the player from moving faster on the diagonal
         rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        //if (transform.position.x < -10 ) {
        //    transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        //}
    }

}