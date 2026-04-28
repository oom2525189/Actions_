using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tokei : MonoBehaviour
{

    public tyekka playerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hanma")
        {
            //変数に+1してクリア画面に持ち越す　変数の値でクリア画面の次のステージが変わる　タイトルに戻ると初期化　変数マネはシーンをまたいでも残る

            playerScript.hanntei++;

            Destroy(gameObject);

            //クリアシーンに移動　時間をおいてもよい
        }
    }
}
