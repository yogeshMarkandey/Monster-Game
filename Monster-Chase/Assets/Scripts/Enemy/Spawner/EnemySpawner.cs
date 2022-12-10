using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsters;

    [SerializeField]
    private Transform left, right;

    private GameObject player;

    private GameObject spawnedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (player)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            int randomIndex = Random.Range(0, monsters.Length);
            int randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(monsters[randomIndex]);

            if(randomSide == 0)
            {
                spawnedEnemy.transform.position = left.position;
            }
            else
            {
                spawnedEnemy.transform.position = new Vector3(right.position.x - 2, right.position.y, right.position.z);
            }
        }
    }
}
