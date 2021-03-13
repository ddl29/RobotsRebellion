using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float speed = 5;
    public Rigidbody2D  rb;
    private Animator anim;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      movement.x= Input.GetAxisRaw("Horizontal");
      movement.y= Input.GetAxisraw("Vertical");
      
    }
    void FixedUpdate()
    {
      rb.MovePosition(rb.position + movement * speed * Time.fixeDeltaTime);

    }
}
