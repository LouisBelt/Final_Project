using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject camera;
    private float health = 100f;
    private float startPos;
    private float smoothSpeed = 0.8f; // Adjust this value to control the smoothness of the movement
    [SerializeField] private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        startPos = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            startPos += 0.01f;
            float targetPos = startPos; // Calculate the target position based on your game logic
            Vector3 desiredPosition = new Vector3(targetPos, 0, 0);
            Vector3 smoothedPosition = Vector3.Lerp(camera.transform.position, desiredPosition, smoothSpeed);
            camera.transform.position = smoothedPosition;
        }
        else{
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet"){
            decreaseBar(5);
        }
        else if(collision.tag == "RobotBullet"){
            Debug.Log(collision.tag);
            decreaseBar(10);
        }
        else if(collision.tag == "Hand"){
            decreaseBar(30);
        }
        else if(collision.tag == "Bomb"){
            decreaseBar(50);
        }
        else if(collision.tag == "Coin"){
            increaseBar(1);
            Destroy(collision.gameObject);
        }
    }

    public void decreaseBar(float damage){
        health -= damage;
        healthBar.fillAmount = health / 100f;
    }

    public void increaseBar(float amount){
        if(health < 100){
            health += amount;
            health = Mathf.Clamp(health, 0, 100);
        }

        healthBar.fillAmount = health / 100f;
    }
}
