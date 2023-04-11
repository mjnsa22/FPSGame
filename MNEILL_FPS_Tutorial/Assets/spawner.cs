using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Enemy enemy;
    public float spawnRate;
    private float time = 3.0f;
    public GameManager gameManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnRate)//if it is time to spawn an enemy
        {
            time = 0f;
            Enemy instance = Instantiate(enemy);//make a new enemy
            instance.player = player;//assign essential variables
            instance.gameManager = gameManager;
        }
    }
}
