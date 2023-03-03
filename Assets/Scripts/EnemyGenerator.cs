using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵のプレハブ
    public float spawnInterval = 1f; // 敵を生成する間隔
    public float spawnDelay = 0f; // 敵を生成するまでの待ち時間

    // Start is called before the first frame update
    void Start()
    {
        // 指定した待ち時間後、敵を生成するコルーチンを開始する
        StartCoroutine(SpawnEnemies());
    }

    // 指定した間隔で敵を生成するコルーチン
    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            // 敵のプレハブから新しい敵を生成する
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // 指定した間隔で繰り返し敵を生成する
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
