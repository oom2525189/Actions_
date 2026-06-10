using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class hasiri : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
        public float speed =30.0f;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
