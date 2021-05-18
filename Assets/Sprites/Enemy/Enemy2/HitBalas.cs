using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBalas : MonoBehaviour
{
    public GameObject explosion;   
    void OnTriggerEnter2D(Collider2D c){
        if(c.CompareTag("Bala1") | c.CompareTag("Bala2")){
            Destroy(c.gameObject);
            GameObject effect = Instantiate(explosion,c.transform.position,Quaternion.identity);
            Destroy(effect,.5f);
        }
    }
}
