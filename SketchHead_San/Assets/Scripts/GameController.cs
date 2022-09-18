using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Platform gameobject
    [Header("Platform Object")]
    public GameObject platform;
    //Default position for platform
    public float pos = 0;
    //Game Over Canvas
    [Header("Game Over UI Canvas Object")]
    public GameObject gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 1000; i++)
        {
            //execture SpawnPlatforms
            SpawnPlatforms();
        }
    }

    void SpawnPlatforms()
    {
        //spawn platforms randomly on x-axis and places them on y-axis every 2.5 seconds
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 2.5f;
    }
    //game over function
    public void GameOver()
    {
        //game Over Canvas is active
        gameOverCanvas.SetActive(true);
    }
      
}
