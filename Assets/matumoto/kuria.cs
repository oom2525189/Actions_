using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kuria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tyekka ty; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("kuriatyekka"); //kuriatyekkaっていうオブジェクトを探す
        ty = obj.GetComponent<tyekka>(); //付いているスクリプトを取得
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (ty.hanntei)
            {
                case 1:
                    SceneManager.LoadScene("matumoto");//  仮でmatumotoへ
                    break;
                case 2:
                    SceneManager.LoadScene("st3");
                    break;


            }
        }
         
        
       
    


    }

}
