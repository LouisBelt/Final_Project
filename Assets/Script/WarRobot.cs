using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarRobot : MonoBehaviour
{
    private float health = 300f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(health <= 0f){
            animator.SetTrigger("Damaged");
            Destroy(gameObject,1.0f);
        }
        else if(collision.tag == "PlayerBullet"){
            Debug.Log("Hit Robot");
            animator.SetTrigger("Damaged");
            health -= 10;
            animator.SetTrigger("Not Damaged");
        }
    }
}
