using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject copEnemy;
    public GameObject player;
    public float spx,spy; // spawn point x ve y
    float tempSpawnPoint=0f;
    Vector2 spawnPoint= new Vector2(0f, 0f);
    public float spawnTime=15f;

    void Start()
    {
        Invoke("createEnemy", 0f);
        InvokeRepeating("diffucultTime", 0f, 15f);
    }

    void Update()
    {
        
    }

    void createEnemy()
    {
        print("create enemy");
        spawnPoint = new Vector2((player.transform.position.x + spx), player.transform.position.y + spy);
        if (spawnPoint.x == tempSpawnPoint)
        {
            spawnPoint.x += 1;
        }
        tempSpawnPoint = spawnPoint.x;
        Instantiate(copEnemy, spawnPoint,Quaternion.identity);
        Invoke("createEnemy", spawnTime);
    }

    void diffucultTime()
    {
        if(spawnTime>3f)
        spawnTime -= 1f;
    }
}
