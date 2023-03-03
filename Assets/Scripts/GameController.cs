using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 機能要件
// ・UIの作成
// ・UIの更新
// ・敵と弾がぶつかった時に更新
// ・リトライの実装
    // ・spaceを押したらシーンを再読み込み


public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public Text ScoreText;
    int score = 0;

    void Start()
    {
        gameOverText.SetActive(false);
        ScoreText.text = "SCORE:" + score;
    }

    //スコア加算
    public void AddScore()
    {
        score += 100;
        ScoreText.text = "SCORE:" + score;
    }

    //ゲームオーバー表示
    public void GameOver()
    {
        gameOverText.SetActive(true);
    }


    // Update is called once per frame

    private void Update()
    {
        if(gameOverText.activeSelf == true)
        {
             if(Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("main");
                }
        }
      
    }
}