using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null){

            if(Input.GetKeyDown(KeyCode.O)){
                animator.SetTrigger("Damage");
            }

            if(Input.GetKeyDown(KeyCode.C)){
                animator.SetTrigger("Done_Damage");
            }

        }
    }
}
