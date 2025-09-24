using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winLoseText;

    public PlayerController playerScript;
    public GameObject playerRef;
    public GameObject enemyRef;
    [SerializeField]
    private List<GameObject> enemyArray = new List<GameObject>();
    private int deadEnemies;

    bool coroutineRunning = false;

    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyRef.transform.childCount; i++)
        {
            if (enemyRef.transform.GetChild(i).tag == "Enemy")
            {
                enemyArray.Add(enemyRef.transform.GetChild(i).gameObject);
            }
        }
    }

    IEnumerator GameOver()
    {
        coroutineRunning = true;
        Debug.Log("Game Over");
        winLoseText.gameObject.SetActive(true);
        winLoseText.text = "You lose!!";
        yield return new WaitForSeconds(1.5f);
        playerScript.Respawn();
        //enemyManager.SpawnAllEnemies();
        winLoseText.gameObject.SetActive(false);
        coroutineRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerRef.activeSelf && !coroutineRunning)
        {
            StartCoroutine(GameOver());
        }

            foreach (GameObject enemy in enemyArray)
            {
                if (!enemy.activeSelf)
                {
                    deadEnemies++;
                }
            }

        if (deadEnemies == enemyManager.enemyAmount)
        {
            StartCoroutine(GameOver());

            Debug.Log("Game Win! :D");
            winLoseText.gameObject.SetActive(true);
            winLoseText.text = "You win!!";
        }
        deadEnemies = 0;

    }
}
