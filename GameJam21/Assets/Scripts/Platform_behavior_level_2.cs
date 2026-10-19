using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_behavior_level_2 : MonoBehaviour
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


        //Plattform ist die aktuelle Plattform und lässt sich bewegen
        if (gameObject.tag == "Active_platform")
        {
            //renderer aktivieren damit das Objekt gesehen wird
            renderer.enabled = true;

            //Geschwindigkeit
            float movementSpeed = 5;

            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical");

            //update the position
            transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);
        }


        //Plattform ist noch nicht zu sehen und noch nicht physikalisch vorhanden, da sie noch nicht dran ist
        if (gameObject.tag == "Waiting_platform")
        {
            renderer.enabled = false;
            collider.enabled = false;


        }


        //Plattform wurde platziert und ist nun fest im Bild verankert
        if (gameObject.tag == "Placed_platform")
        {
            //collider aktivieren damit das Objekt physikalisch da ist
            collider.enabled = true;
        }
    }
}

