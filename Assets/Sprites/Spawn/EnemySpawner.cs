using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float respawnTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
     GameObject a = Instantiate(enemy) as GameObject;
     a.transform.position = new Vector2(-0.09f,0.99f);
    }

    IEnumerator enemyWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }

    }

}
