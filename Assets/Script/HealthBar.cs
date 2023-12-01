using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public Image healthBar;
    public float Health = 100f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseBar(float damage){
        Health -= damage;
        healthBar.fillAmount = Health / 100f;
    }

    public void increaseBar(float amount){
        Health += amount;
        Health = Mathf.Clamp(Health, 0, 100);

        healthBar.fillAmount = Health / 100f;
    }
}
