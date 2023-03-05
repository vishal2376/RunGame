using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 0.5f;

    private float _timer = 0;


    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < spawnTime)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            _timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        var randomLaneEdge = (Random.Range(0, 2) * 2) - 1;
        
        var currentPosition = transform.position;
        var enemySpawnPos = new Vector3(randomLaneEdge * currentPosition.x ,currentPosition.y,currentPosition.z);
        
        Instantiate(enemy, enemySpawnPos, Quaternion.identity);
    }
}