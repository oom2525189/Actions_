using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class titenn : MonoBehaviour
{

    [SerializeField] GameObject tokei;
    public int i = 0;
    public bool taiki = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (transform.position == tokei.transform.position)
        {
            taiki = true;
            if (other.CompareTag("Player"))
                switch (i)
                {
                    case 0:
                        transform.position = new Vector3(7.18f, -11.44f, -32.55f);
                        i = 1;
                        break;
                    case 1:
                        transform.position = new Vector3(15.8f, -11.44f, -32.55f);
                        i = 2;
                        break;
                    case 2:
                        transform.position = new Vector3(19.25f, -11.44f, -25.07f);
                        i = 3;
                        break;
                    case 3:
                        transform.position = new Vector3(12.34f, -11.44f, -13.78f);
                        i = 4;
                        break;
                    case 4:
                        transform.position = new Vector3(22.97f, -11.44f, -13.78f);
                        i = 5;
                        break;
                    case 5:
                        transform.position = new Vector3(22.97f, -11.44f, -17.95f);
                        i = 6;
                        break;
                    case 6:
                        transform.position = new Vector3(20.55f, -11.44f, -22.76f);
                        i = 7;
                        break;
                }
        }
        else
            taiki = false;
    }

}
