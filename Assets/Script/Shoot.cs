using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera main;
    private Vector3 mouseLocation;
    public GameObject bullet;
    public Transform Aim;
    private float timer;
    public float firingRate;
    public bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseLocation = main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mouseLocation - transform.position;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rot);

        if(!canFire){
            timer += Time.deltaTime;
            if(timer > firingRate){
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire){
            canFire = false;
            Instantiate(bullet, Aim.position, Quaternion.identity);
        }

    }
}