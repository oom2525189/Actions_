using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tobi : MonoBehaviour
{
    // Start is called before the first frame update
    public int x = 0;
    public int y = 0;
    public int z = 0;
   

    void Start()
    {
        x = Random.Range(-300, 301);　
        y = Random.Range(10,301 );　
        z = Random.Range(-300, 301);
        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        Vector3 force = new Vector3(x, y, z);    // 力を設定
        rb.AddForce(force);  // 力を加える
    }

    // Update is called once per frame
    void Update()
    {
        
            Destroy(gameObject,5.0f);
        
    }
}
