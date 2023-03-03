using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float moveSpeed = 2f; // 敵の移動速度
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ
    public float bulletSpeed = 10f; // 弾の速度
    public GameObject bulletPrefab; // 弾のプレハブ
    public float shootInterval = 2f; // 弾を発射する間隔
    public float health = 3f; // 敵の体力

    private bool isAlive = true; // 敵が生きているかどうか
    private float timeSinceLastShot = 0f; // 前回弾を発射してからの時間

    GameController GameController; //他のオブジェクトのコンポーネントを利用したいので箱を定義

    //敵を左右に揺らせる
    //スコアの表示
    //敵を倒した時のスコアを上昇させる
    
    //ゲームオーバーの実装
        // ・UIを作成
        // ・敵とプレイヤーがぶつかった時にUIを表示
        // ・リトライの実装

    //音の実装
    //敵が左右に移動する
    //player移動範囲指定
    //弾と敵の表示範囲制限

    // Start is called before the first frame update
    void Start()
    {
        // 敵を生成する
        transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 6f, 0f);
        // GameContorollerオブジェクトのGameContorollerコンポーネントを取得する
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            // 敵を下方向に移動する
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // 一定時間ごとに弾を発射する
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootInterval)
            {
                Fire();
                timeSinceLastShot = 0f; 
            }
        }
    }

    // 敵に弾が当たったら爆発する
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // 弾のインスタンスを破壊する
            Destroy(collision.gameObject);

            // 敵の体力を減らす
            health--;

            if (health <= 0)
            {
                // 爆発エフェクトを生成する
                Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);

                // 敵を破壊する
                Destroy(gameObject);
                
                // 爆破音SE
                SoundManager.instance.PlaySE(SoundManager.SE.explosion);

                //点数加算
                GameController.AddScore();

                isAlive = false;
            }
        }
        else if (collision.CompareTag("Player"))
        {
            // 爆発エフェクトを生成する
            Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);

            // Playerを破壊する
            Destroy(collision.gameObject);

            // 敵を破壊する
            Destroy(gameObject);

            // 爆破音SE
            SoundManager.instance.PlaySE(SoundManager.SE.explosion);

            // ゲームオーバー表示
            GameController.GameOver();

            isAlive = false;
        }
    }

    // 弾を発射する
    void Fire()
    {
        // 弾をつくる
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 弾の動きを作る
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector3.down * bulletSpeed;
    }
}

