using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 1;

    public float obstacleSpeed = 10;

    public float obstacleOffsetX = 0;

    public Vector2 ObstacleOffsetY = new Vector2(0, 0);

    [HideInInspector]
    public int score;

    [HideInInspector]
    private bool isGameOver = false;

    void Awake(){
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    } 
    
    public bool IsGameActive() {
        return !isGameOver;
    }

    public bool IsGameOver() {
        return isGameOver;
    }

    public void EndGame() {
        // set flag
        isGameOver = true;
        Debug.Log("Game Over... Your score was: " + score);

        //Reload Scene
        StartCoroutine(RealoadScene(2));
    }

    private IEnumerator RealoadScene (float delay) {
        //Wait 2 seconds (Delay)        
        yield return new WaitForSeconds(delay);

        //Reload the scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene please!!");
    }
}


