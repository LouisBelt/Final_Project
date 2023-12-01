using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    private float health = 500f;
    private Animator animator;
    private GameObject camera;
    private bool movingRight = false;
    private float moveSpeed = 3f;
    private float leftBound;
    private float rightBound;
    private int rotation = 3;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        rightBound = camera.transform.position.x + 1.57f;
        leftBound = camera.transform.position.x - 1.51f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotation <= 0){
            GetComponent<BoxCollider2D>().enabled = false;
            timer += Time.deltaTime;
            if(timer > 5){
                timer = 0;
                rotation = 3;
                GetComponent<BoxCollider2D>().enabled = true;
            }
            return;
        }
        rightBound = camera.transform.position.x + 1.57f;
        leftBound = camera.transform.position.x - 1.51f;
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                rotation -= 1;
            }
        }
        
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                rotation -= 1;
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(health <= 0f){
            animator.SetTrigger("Damage");
            Destroy(gameObject);
        }
        else if(collision.tag == "PlayerBullet"){
            Debug.Log("Hit");
            animator.SetTrigger("Damage");
            health -= 10f;
            Debug.Log(health);
            animator.SetTrigger("Damage_done");
        }
    }
}