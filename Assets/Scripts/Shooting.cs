using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour

{
   private Camera mainCam;
   private Vector3 mousePos;
   public GameObject bullet;
   public Transform bulletTransform;
   public bool canfire;
   private float timer;
   public float timeBetweenFiring;
   public Animator anim;
   private GameObject ArrowInstance;
   [SerializeField] private AudioSource arrowShootingSoundEffect;

   
 // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

       
        timer += Time.deltaTime;
        
       

       
       if(Input.GetMouseButton(0) && timer > timeBetweenFiring)
        {
            timer = 0f;
            ArrowInstance = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            //anim.SetTrigger("Active");
            arrowShootingSoundEffect.Play();

            

            
        }

        Destroy(ArrowInstance, 2.0f);
    }
}
