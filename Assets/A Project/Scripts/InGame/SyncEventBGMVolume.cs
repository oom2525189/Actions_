using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SyncEventBGMVolume : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        ApplyVolume();
    }

    void OnEnable()
    {
        // パネル（オブジェクト）が表示された瞬間にも最新の音量を適用する
        ApplyVolume();
    }

    void Update()
    {
        // 念のため、再生中も常に音量を同期する（時計のスクリプトと同じ仕組み）
        ApplyVolume();
    }

    private void ApplyVolume()
    {
        if (audioSource != null)
        {
            // SoundManagerが使っている「BGM_VOLUME_KEY」と同じセーブデータから音量を読み込む
            float savedVolume = PlayerPrefs.GetFloat("BGM_VOLUME", 0.5f);
            audioSource.volume = savedVolume;
        }
    }
}