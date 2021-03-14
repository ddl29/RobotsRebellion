using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
     public Animator animator;
     Rigidbody2D rb;
     Vector2 movement;
     Vector3 dir;
     public GameObject bones;
     public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = (target.transform.position-transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
        animator.SetFloat("x",movement.x);
        animator.SetFloat("y",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala1"))
        {   
            Destroy(gameObject);
            GameObject effect2 = Instantiate(bones,transform.position,Quaternion.identity);
            Destroy(effect2,5f);
        }
    }
}
