using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject enemy1;
    public GameObject destroy;

    public bool stop = false;
    public float spawnTime;
    public float spawnDelay;

    public float spawnLife;
    Player playerScript;

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void Start()
    {
        spawnTime = 1;
        spawnDelay = 9;
        spawnLife = 30;
        InvokeRepeating("EnemySpawn",spawnTime,spawnDelay);
      
    }
    public void EnemySpawn(){
      
        Vector2 SpawnPos = new Vector2(18.14f,-9.05f);
         Instantiate(enemy1,SpawnPos,Quaternion.identity);
         if(stop){
           
           CancelInvoke("EnemySpawn");
         }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala1"))
        {   spawnLife -=1;
            if (spawnLife<=0){
            Destroy(gameObject);
            GameObject explosion = Instantiate(destroy,transform.position,Quaternion.identity);
            Destroy(explosion,1.25f);
            Destroy(gameObject);

            stop = true;
            }
        }
    }
}
