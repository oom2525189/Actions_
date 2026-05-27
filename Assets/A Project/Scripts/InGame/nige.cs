using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class nige : MonoBehaviour
{
    public bool idou = false;

    float speed = 10.0f;

    public Animator tokeianimation;

    public bool run = false;
    public bool jump = false;
    public bool koke = false;

    //titenn moku; //呼ぶスクリプトにあだなつける
    //GameObject obj = GameObject.Find("mokuhyou"); //Playerっていうオブジェクトを探す
    //moku = obj.GetComponent<titenn>(); //付いているスクリプトを取得

    // Start is called before the first frame update
    public titenn playerScript;
    public int bCount;
    void Start()
    {
       
    }
    // Update is called once per frame
    [SerializeField] GameObject target;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            idou = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            idou = false;
        }
    }
    void Update()
    {
        bCount = playerScript.i;

        if (idou)
        {
            

            if (bCount == 5 || bCount == 6)
                jump = true;
            else if(bCount == 7)
                koke = true;
            else
            run = true;

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
        else
        {
            run = false;
            jump = false;
            koke = false;
        }
        tokeianimation.SetBool("run", run);
        tokeianimation.SetBool("jump", jump);
        tokeianimation.SetBool("kokeru", koke);

    }


}
