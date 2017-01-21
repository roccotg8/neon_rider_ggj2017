using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOne : MonoBehaviour
{
 
    public GameObject EnemyOne;                // The enemy prefab to be spawned.
    //public float spawnTime = 3f;            // How long between each spawn.
    bool bossTime = false;
    public const int MAX_SPAWNS = 3;
    int spawnCount;
    //public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        spawnCount = 0;
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Update()
    {

        while (!bossTime && spawnCount < MAX_SPAWNS)
        {

            Spawn();
            spawnCount++;
        }

    }


    void Spawn()
    {

        float spawnY = Random.Range(0, Camera.main.ScreenToWorldPoint(new Vector2(0, (Screen.height))).y);
        float spawnX = Random.Range(0, Camera.main.ScreenToWorldPoint(new Vector2(0, (Screen.width))).x*-0.1f);
        //Vector2 spawnPosition = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2((Screen.width)*-0.1f, 0)).x, spawnY);
        Vector2 spawnPosition = new Vector2(spawnY, spawnX);

        // Find a random index between zero and one less than the number of spawn points.
        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(EnemyOne, spawnPosition, Quaternion.identity);
    }
}