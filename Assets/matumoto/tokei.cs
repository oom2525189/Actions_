using UnityEngine;

public class tokei : MonoBehaviour
{

    public GameObject hahennPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hanma")
        {
            
            Destroy(gameObject);

        }
    }

    private void OnDestroy()
    {
       Instantiate(hahennPrefab, this.transform.position, Quaternion.identity); //弾を生成

    }
}
