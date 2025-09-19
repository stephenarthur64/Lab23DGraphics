using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winLoseText;

    public GameObject playerRef;
    public GameObject enemyRef;
    [SerializeField]
    private List<GameObject> enemyArray = new List<GameObject>();
    private int activeEnemies;
    const int maxEnemies = 15;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < maxEnemies; i++)
        //{
        //    enemyArray[i] = enemyRef.transform.GetChild(i).gameObject;
        //}

        for (int i = 0; i < enemyRef.transform.childCount; i++)
        {
            if (enemyRef.transform.GetChild(i).tag == "Enemy")
            {
                enemyArray.Add(enemyRef.transform.GetChild(i).gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerRef.activeSelf)
        {
            Debug.Log("Game Over");
            winLoseText.gameObject.SetActive(true);
            winLoseText.text = "You lose!!";
        }

        foreach (GameObject enemy in enemyArray)
        {
            if (!enemy.activeSelf)
            {
                activeEnemies++;
            }
        }

        if (activeEnemies == maxEnemies)
        {
            Debug.Log("Game Win! :D");
            winLoseText.gameObject.SetActive(true);
            winLoseText.text = "You win!!";
        }
        activeEnemies = 0;

    }
}
