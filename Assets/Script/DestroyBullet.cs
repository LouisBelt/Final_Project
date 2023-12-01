using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Bat" && gameObject.tag != "EnemyBullet"){
            Debug.Log(gameObject.tag);
            Destroy(gameObject);
        }

    }

}
