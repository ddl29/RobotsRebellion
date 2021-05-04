using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform [] points;
    public float speed = 5f;
    private int currentTargetIndex;
    Transform currentTargetPoint;
    Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public bool active;
    void Start()
    {
        currentTargetIndex = 0;
        currentTargetPoint = points[currentTargetIndex];
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        active = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
        movement = (currentTargetPoint.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, points[currentTargetIndex].position,speed * Time.deltaTime);
        this.animator.SetFloat("x",movement.x);
        this.animator.SetFloat("y",movement.y);
        this.animator.SetFloat("Speed",movement.sqrMagnitude);
        animator.SetBool("Stop",false);
        if (Vector2.Distance(transform.position, currentTargetPoint.position) < 0.2f)
        {
            animator.SetBool("Stop",true);
            if(currentTargetIndex + 1 < points.Length){
                currentTargetIndex ++;
            }
            else{
                currentTargetIndex = 0;
            }
            currentTargetPoint = points[currentTargetIndex];
            }
        }
                
    }
}
