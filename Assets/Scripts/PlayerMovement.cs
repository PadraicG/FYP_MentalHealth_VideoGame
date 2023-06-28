using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        

    }

    void FixedUpdate() 
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        //movement and physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(movement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 5);
        }
        if(movement.x <0)
        {
                        gameObject.transform.localScale = new Vector3(-5, 5, 5);

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
    }
}
