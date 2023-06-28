using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bullet script started");
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = transform.position - playerTransform.position;
        rb.velocity = direction.normalized * force;

        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 90);

        // Add this line to apply force to rigidbody
        rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
    
        
    }

    // Update is called once per frame
   void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        // Check if the object we collided with has a "Breakable" tag
        if (collision.gameObject.CompareTag("Breakable"))
        {
            Debug.Log("Bullet collided with " + collision.gameObject.name + " with Breakable tag");
            
            // Destroy the pot
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Bullet collided with " + collision.gameObject.name + " but did not break it");
        }

        // Destroy this object
        Destroy(gameObject);
    }
}
