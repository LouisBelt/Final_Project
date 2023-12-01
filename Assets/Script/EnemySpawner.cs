using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject JetpackEnemy;
    [SerializeField] private GameObject robot;
    [SerializeField] private GameObject Hand;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject camera;
    private float jetpackEnemyInterval = 10f;
    private float HandInterval = 100f;
    private float bombEnemyInterval = 50f;
    private float robotEnemyInterval = 70f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFlyingObjects(jetpackEnemyInterval,JetpackEnemy));
        StartCoroutine(spawnFlyingObjects(bombEnemyInterval,bomb));
        StartCoroutine(spawnHand(HandInterval,Hand));
        StartCoroutine(spawnRobot(robotEnemyInterval,robot));
    }

    void Update(){

    }


    private IEnumerator spawnFlyingObjects(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(camera.transform.position.x - 5,camera.transform.position.x + 10), Random.Range(camera.transform.position.y,camera.transform.position.y + 3), 0), Quaternion.identity);
        newEnemy.transform.parent = camera.transform;
        StartCoroutine(spawnFlyingObjects(interval,enemy));
    }

    private IEnumerator spawnHand(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(camera.transform.position.x + 1.57f,-0.41f,0f), Quaternion.identity);
        newEnemy.transform.parent = camera.transform;
        StartCoroutine(spawnHand(interval,enemy));
    }

    private IEnumerator spawnRobot(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(camera.transform.position.x + 0.57f,-0.31f,0f), Quaternion.identity);
        newEnemy.transform.parent = camera.transform;
        StartCoroutine(spawnRobot(interval,enemy));
    }
}
