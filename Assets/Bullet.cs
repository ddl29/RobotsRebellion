using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
  
    public GameObject explosion;
    void Start()
    {
        
    }

   
    void Update()
    {
      ;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
       
        }
        if(collision.CompareTag("Piedra") || collision.CompareTag("Claca"))
        {
        GameObject effect = Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(effect,.5f);
        Destroy(gameObject);
        }
    }
    void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
        else
        {
        GameObject effect = Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(effect,.5f);
        Destroy(gameObject);
        }
    }
 

}
