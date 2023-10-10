using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Fields
    public Transform parentObj;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float nextTimeForSpawn;
    private float spawnTime;
    #endregion
    
    #region Unity Methods
    void Start()
    {

    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            spawnTime += Time.deltaTime;
            if(spawnTime >= nextTimeForSpawn)
            {
                SpawnEnemies();
                spawnTime = 0;
            }
        }
    }
    #endregion

    #region Methods
    private void SpawnEnemies()
    {
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity, parentObj);
    }
    #endregion
}
