using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebensanzeige_script : MonoBehaviour
{


    public GameObject heart1, heart2, heart3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (Leben.leben)
        {
            case 3:
                //gameObject.transform.position = originalPos;
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                Debug.Log("C3 " + (Leben.leben));
                break;
            case 2:
                //gameObject.transform.position = originalPos;
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                Debug.Log("C2 " + (Leben.leben));
                break;
            case 1:
                //gameObject.transform.position = originalPos;
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                Debug.Log("C1 " + (Leben.leben));
                break;
        }
    }
}
