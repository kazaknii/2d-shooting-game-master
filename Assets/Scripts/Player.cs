using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // 移動速度
    [SerializeField] private GameObject bulletPrefab; // 弾のPrefab
    [SerializeField] private int maxLife = 3; // 最大残機数
    private int life; // 残機数
    [SerializeField] private Text lifeText; // 残機数を表示するTextオブジェクト

    private void Start()
    {
        life = maxLife; // 残機数を初期化
    }

    private void Update()
    {
        Move(); // 移動処理を実行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(); // 弾を発射
        }

        // 残機数を表示する
        lifeText.text = "Life: " + life;
    }

    // 移動処理
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.position.x + x, -2.5f, 2.5f); // 移動範囲を制限
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    // 弾を発射する
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    // 当たり判定を処理する
    private void Hit()
    {
        life--;
        if (life <= 0)
        {
            // ゲームオーバー処理を実行
        }
    }

    // 残機数を管理するプロパティ
    public int Life
    {
        get { return life; }
    }
}
