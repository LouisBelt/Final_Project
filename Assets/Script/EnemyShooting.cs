using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public int interval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > interval){
            timer = 0;
            shoot();
        }
    }

    void shoot(){
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}