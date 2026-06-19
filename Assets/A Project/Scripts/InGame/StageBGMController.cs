using UnityEngine;

public class StageBGMController : MonoBehaviour
{
    [SerializeField] private AudioClip stageBGM;

    [Header("監視するパネル（インスペクターから登録）")]
    [SerializeField] private GameObject kuriaPanel;
    [SerializeField] private GameObject gameoverPanel;

    private bool hasStopped = false; // 二重にストップ処理が走るのを防ぐフラグ

    void Start()
    {
        if (SoundManager.instance != null && stageBGM != null)
        {
            SoundManager.instance.PlayBGM(stageBGM);
        }
    }

    void Update()
    {
        // すでに止めている場合は何もしない
        if (hasStopped) return;

        // クリアパネル、またはゲームオーバーパネルのどちらかがアクティブ（true）になったら
        if ((kuriaPanel != null && kuriaPanel.activeSelf) ||
            (gameoverPanel != null && gameoverPanel.activeSelf))
        {
            StopStageBGM();
        }
    }

    private void StopStageBGM()
    {
        if (SoundManager.instance != null)
        {
            // SoundManagerのBGMを止める（方法AのStopBGM関数を作っていない場合は、直接AudioSourceを操作してもOK）
            // ここでは一番シンプルな直接停止の方法にしています
            SoundManager.instance.StopBGM();
            hasStopped = true;
        }
    }
}