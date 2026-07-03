using UnityEngine;

public class tokei : MonoBehaviour
{

    public AudioClip breakSound;
    public GameObject hahennPrefab;
    public GameObject hahenn;
    private void OnDestroy()
    {
        float seVolume = PlayerPrefs.GetFloat("SE_VOLUME", 0.5f);
        AudioSource.PlayClipAtPoint(breakSound, transform.position, seVolume);
        Instantiate(hahennPrefab, this.transform.position, Quaternion.identity); //弾を生成
        Instantiate(hahenn, this.transform.position, Quaternion.identity);
    }
}
