using UnityEngine;

public class tokei : MonoBehaviour
{

    public AudioClip breakSound;
    public GameObject hahennPrefab;
    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        Instantiate(hahennPrefab, this.transform.position, Quaternion.identity); //弾を生成

    }
}
