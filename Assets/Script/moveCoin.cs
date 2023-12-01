using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCoin : MonoBehaviour
{

    private float timer;
    private float moveSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        if(timer > 10){
            Destroy(gameObject);
        }
    }
}
