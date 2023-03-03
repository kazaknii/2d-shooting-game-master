using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 音を鳴らす
    // ・AudioSource: スピーカー
    // ・AudioClip: 曲

    // BGM
    [SerializeField] AudioSource audioSourceBGM = default;
    [SerializeField] AudioClip[] bgmCrips = default;
    // SE
    [SerializeField] AudioSource audioSourceSE = default;
    [SerializeField] AudioClip[] seCrips = default;
    
    public enum BGM //列挙型
    {
        firstStage, 
        secondStage
    }
    
    public enum SE //列挙型
    {
        shot, //弾を打つ
        explosion //爆発する
    }

    // シングルトンにしてやる
    // ・ゲーム内にただ１つだけのもの
    // ・シーンが変わっても破壊されない
    // ・どのコードからもアクセスしやすい
    // ・決まり文句

    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null) 
        {
         instance = this;
         DontDestroyOnLoad(gameObject);
        }   
        else
        {
            {
                Destroy(gameObject);
            }
        }    
    }

    private void Start()
    {
       SoundManager.instance.PlayBGM(SoundManager.BGM.secondStage);//テスト
    }
    
    public void PlayBGM(BGM bgm)
    {
        audioSourceBGM.clip = bgmCrips[(int)bgm];
        audioSourceBGM.Play();
    }  
    
    public void PlaySE(SE se)
    {
        audioSourceSE.PlayOneShot(seCrips[(int)se]);
    }   
}
