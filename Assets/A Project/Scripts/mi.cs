using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public float speed = -30.0f;
    int i = 0;
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
            transform.Rotate(0, speed * Time.deltaTime, 0);

        if ((i==1))
        {
           
            
        }
        
    }
}

