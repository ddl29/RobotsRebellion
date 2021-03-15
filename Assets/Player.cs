using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed  = 5f;
     float speed_bullet = 100f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public Text restart;
    bool vivo;
    public GameObject crosshair;
     float crosshairdist ;
    public GameObject bulletPrefab;
    Vector2 damage;





    void Start()
    {
        crosshairdist = 2f;
        restart.gameObject.SetActive(false);
        vivo = true;
    }

    void Update()
    {
        if(vivo){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        Aim();
        Shoot();


        }
         if(Input.GetKeyDown(KeyCode.Space)){
         vivo = true;
         Vida.VidaCont = 100;
         restart.gameObject.SetActive(false);

         
         }
         
    }
 
    void FixedUpdate()
    {
        if(vivo){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
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
            GameObject bullet = Instantiate(bulletPrefab,new Vector2(transform.position.x + shootdir.x, transform.position.y+shootdir.y), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootdir * speed_bullet;
            bullet.transform.Rotate(0,0,Mathf.Atan2(shootdir.y,shootdir.x) * Mathf.Rad2Deg);
            Destroy(bullet,2f);

        }
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemy1")){
            Vida.VidaCont -= 5;
            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x +Random.Range(0,2), transform.position.y + Random.Range(0,2));


            if(Vida.VidaCont <=0)
            {
                vivo = false;
                Vida.VidaCont = 0;
                restart.gameObject.SetActive(true);
               
               
            }
        }
    }
}
