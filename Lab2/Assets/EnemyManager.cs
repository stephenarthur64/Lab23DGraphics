using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyAmount = 10;
    public GameObject enemyPrefab;
    public List<GameObject> spawnPositions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllEnemies();
    }

    void SpawnAllEnemies()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            int randomPos = Random.Range(0, spawnPositions.Count);
            Instantiate(enemyPrefab, spawnPositions[randomPos].transform.position, Quaternion.identity, this.transform);
            
        }
    }
}
