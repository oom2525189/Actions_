using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tokei : MonoBehaviour
{

    public GameObject hahennPrefab;

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

            Destroy(gameObject);

            //クリアシーンに移動　時間をおいてもよい
        }
    }

    private void OnDestroy()
    {
       Instantiate(hahennPrefab, this.transform.position, Quaternion.identity); //弾を生成


        //tyekka ty; //呼ぶスクリプトにあだなつける
        //GameObject obj = GameObject.Find("kuriatyekka"); //kuriatyekkaっていうオブジェクトを探す
        //ty = obj.GetComponent<tyekka>(); //付いているスクリプトを取得

        //ty.hanntei++;

        //SceneManager.LoadScene("kuria");
    }
}
