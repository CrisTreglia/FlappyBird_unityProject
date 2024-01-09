using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float coolDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get gameManager
        var gameManager = GameManager.Instance;

        //Ignore if game is over
        if(gameManager.IsGameOver()) {
            return;
        }

        coolDown -= Time.deltaTime;

        //update cooldown
        if(coolDown <= 0f) {
            coolDown = gameManager.obstacleInterval;

            //Spawn obstacle
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];
            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.ObstacleOffsetY.x, gameManager.ObstacleOffsetY.y);
            float z = 9;
            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
