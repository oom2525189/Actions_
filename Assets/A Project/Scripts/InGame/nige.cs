using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class nige : MonoBehaviour
{

    float speed = 10.0f;
    public Animator tokeianimation;
  
    // Start is called before the first frame update
    void Start()
    {
  titenn moku; //呼ぶスクリプトにあだなつける
    GameObject obj = GameObject.Find("mokuteki"); //Playerっていうオブジェクトを探す
    moku = obj.GetComponent<titenn>(); //付いているスクリプトを取得
    }

    // Update is called once per frame
    [SerializeField] GameObject target;
 

    void Update()
    {
        
        //スタート位置、ターゲットの座標、速度
        transform.position = Vector3.MoveTowards(
          transform.position,
          target.transform.position,
          speed * Time.deltaTime);
        Vector3 direction = target.transform.position - transform.position;
        if (direction != Vector3.zero) // 距離が0のときの警告を防ぐ
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        

    }

    
}
