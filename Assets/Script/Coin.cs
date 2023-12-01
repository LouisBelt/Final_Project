using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float coinInterval = 5f;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoin(coinInterval,coin));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator spawnCoin(float interval, GameObject coin){
        yield return new WaitForSeconds(interval);
        GameObject newCoin = Instantiate(coin, new Vector3(camera.transform.position.x + 1.57f,Random.Range(-0.41f,0),0f), Quaternion.identity);
        newCoin.transform.parent = camera.transform;
        StartCoroutine(spawnCoin(interval,coin));
    }
}
