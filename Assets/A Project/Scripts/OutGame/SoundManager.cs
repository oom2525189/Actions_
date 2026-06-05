using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    //保存用のキーワード（キー）を決めておく
    private const string BGM_VOLUME_KEY = "BGM_VOLUME";
    private const string SE_VOLUME_KEY = "SE_VOLUME";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //ゲーム起動時に保存された音量を読み込む
            LoadVolume();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmAudioSource.volume = volume;

        //音量が変更されたら、その値をパソコンに保存する
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, volume);
        PlayerPrefs.Save(); // 確実に保存を実行
    }

    public void SetSEVolume(float volume)
    {
        seAudioSource.volume = volume;

        PlayerPrefs.SetFloat(SE_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        //保存された値があればそれを読み込む。なければ「0.5（真ん中）」を初期値にする
        float savedVolume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 0.5f);
        float savedSEVolume =
            PlayerPrefs.GetFloat(SE_VOLUME_KEY, 0.5f);

        //音量を適用
        bgmAudioSource.volume = savedVolume;
        seAudioSource.volume = savedSEVolume;
    }
}