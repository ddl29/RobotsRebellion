using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed  = 5f;
    public float speed_bullet = 20f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
 

    public GameObject crosshair;
    public float crosshairdist = 0.1f;
    public GameObject bulletPrefab;


    void Start()
    {
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        Aim();
        Shoot();
      
    }
 
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
       
    }

    void Aim()
    {   
        if(movement != Vector2.zero){
             crosshair.transform.localPosition = movement * crosshairdist;
        }
    }
    void Shoot()
    {
        Vector2 shootdir = crosshair.transform.localPosition;
        shootdir.Normalize();
        if(Input.GetButtonUp("Fire1")){

            GameObject bullet = Instantiate(bulletPrefab,(transform.position), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootdir * speed_bullet;
            bullet.transform.Rotate(0,0,Mathf.Atan2(shootdir.y,shootdir.x) * Mathf.Rad2Deg);
            Destroy(bullet,2f);

        }
        
    }
    

    
}
