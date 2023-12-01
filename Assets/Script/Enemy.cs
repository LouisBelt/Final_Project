using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
            StartCoroutine(DestroyAfterDelay(gameObject, 0.5f));
        }
        else if(collision.tag == "PlayerBullet"){
            Debug.Log("Hit");
            animator.SetTrigger("Damage");
            health -= 10f;
            Debug.Log(health);
            animator.SetTrigger("Done_Damage");
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay) {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
