using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PlayerShipを方向キーで動かす
// ・方向キーの入力を受け付ける
// ・Playerの位置を変更する

// 弾を撃つ
// ・弾をつくる
// ・球の動きを作る（Bullet.cs）
// ・発射ポイントを作る オブジェクト名:FirePoint
// ・スペースボタンを押したときに弾を生成する

// 敵の移動
// 敵を生成
// 敵に弾が当たったら爆発する
// 敵とplayerがぶつかったら爆発する

public class PlayerShip : MonoBehaviour
{
    public float moveSpeed = 5f; // Playerの移動速度
    public GameObject bulletPrefab; // 弾のプレハブ
    public float bulletSpeed = 10f; // 弾の速度
    public Transform firePoint; // 発射ポイント
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ


    //コンポーネントを格納する変数
    GameController GameController;
 

    void Start()
    {
    GameController = GameObject.Find("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        // 方向キーの入力を受け付ける
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Playerの位置を変更する
        transform.position += new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // スペースボタンを押したときに弾を生成する
        if (Input.GetKeyDown(KeyCode.Space))
        {
        // 弾をつくる
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    
        // ショット音を鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.shot);
        
        }
         
    }

    // 敵の弾が当たったら爆発する
    void OnTriggerEnter2D(Collider2D collision)    
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            // Debug.Log(collision.CompareTag("EnemyBullet"));
            
            // 爆発エフェクトを生成する
        Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);

        // 爆発音を鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.explosion);

        // 自機を破壊する
        Destroy(gameObject);

        // ゲームオーバー表示
        GameController.GameOver();
        
        }
    }
    
}

