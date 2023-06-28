using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 5.0f;

    public GameObject crossHair; 
    
    private Vector3 targetAim;

    private Camera cam;
    Vector2 mousePos;

    public enum MovementDirection
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    private MovementDirection currentDirection = MovementDirection.None;



    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, Input.GetAxis("Vertical"), 0.0f);

       // MoveCrossHair();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position += movement * speed * Time.deltaTime;


        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(5, 5, 5);
        }

        if (Input.GetButton("Fire2")) // Check for left mouse button click
        {
            Debug.Log("Left mouse button clicked");
            // Add your code to shoot an arrow here
        }


        if (Input.GetKey(KeyCode.W))
{
    currentDirection = MovementDirection.Up;
}
else if (Input.GetKey(KeyCode.S))
{
    currentDirection = MovementDirection.Down;
}
else if (Input.GetKey(KeyCode.A))
{
    currentDirection = MovementDirection.Left;
}
else if (Input.GetKey(KeyCode.D))
{
    currentDirection = MovementDirection.Right;
}
else
{
    currentDirection = MovementDirection.None;
}

        
    

    
    }

    private void MoveCrossHair()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = mouseCursorPos;
    }

   
//    private void MoveCrossHair()
// {
//     Vector3 aim = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

//     if (aim.magnitude > 0.0f)
//     {
//         aim.Normalize();
//         float distance = 1.0f; // Desired distance between player and crosshair
//         targetAim = aim * distance;
//         crossHair.transform.localPosition = targetAim;
//     }

//     crossHair.transform.localPosition = Vector3.Lerp(crossHair.transform.localPosition, targetAim, Time.deltaTime * 10.0f * 3.0f);
// }

}   
   

