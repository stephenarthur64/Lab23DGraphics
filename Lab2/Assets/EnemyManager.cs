using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyAmount;
    public GameObject enemyPrefab;
    public List<GameObject> spawnPositions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllEnemies();
    }

    public void SpawnAllEnemies()
    {
        foreach (Transform enemy in transform)
        {
            if (enemy.CompareTag("Enemy"))
            {
                DestroyImmediate(enemy.gameObject);
            }
        }

        for (int i = 0; i < enemyAmount; i++)
        {
            int randomPos = Random.Range(0, spawnPositions.Count);
            Instantiate(enemyPrefab, spawnPositions[randomPos].transform.position, Quaternion.identity, this.transform);
        }
    }
}
