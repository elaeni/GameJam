using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_behavior_level1 : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        Collider2D collider = GetComponent<Collider2D>();
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();


        //Plattform ist die aktuelle Plattform und lässt sich bewegen
        if (gameObject.tag == "Active_platform")
        {
            //renderer aktivieren damit das Objekt gesehen wird
            renderer.enabled = true;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;

        }


        //Plattform ist noch nicht zu sehen und noch nicht physikalisch vorhanden, da sie noch nicht dran ist
        if (gameObject.tag == "Waiting_platform")
        {
            renderer.enabled = true;
            collider.enabled = false;
            rigidbody.bodyType = RigidbodyType2D.Static;
        }


        //Plattform wurde platziert und ist nun fest im Bild verankert
        if (gameObject.tag == "Placed_platform")
        {
            //collider aktivieren damit das Objekt physikalisch da ist
            collider.enabled = true;
            rigidbody.bodyType = RigidbodyType2D.Static;
        }
    }
}
