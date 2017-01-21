using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOne : MonoBehaviour
{

    public GameObject enemy1;
    float spawnDistance = 2f;
    public float enemyRate = 20;
    float nextEnemy = 0;
    bool bossSpawn = false;
    int enemyCount = 0;
    public int maxSpawns = 4;

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0 && enemyCount < maxSpawns)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.95f;

            Debug.Log("Enemy spawn");

            if (enemyRate < 5f)
                enemyRate = 5f;

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(enemy1, transform.position + offset, Quaternion.identity);
            enemyCount++;
        }
    }
}

