using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private float health = 100f;
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
            animator.SetTrigger("Dead");
            Destroy(gameObject,1.0f);
        }
        else if(collision.tag == "Player"){
            animator.SetTrigger("Dead");
            Destroy(gameObject,1.0f);
        }
        else if(collision.tag == "PlayerBullet"){
            health -= 10;
        }
    }
}
