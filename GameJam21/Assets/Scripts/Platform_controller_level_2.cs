using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform_controller_level_2 : MonoBehaviour
{
    public int x = 0;
    public int remaining_platforms = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        GameObject.Find("Text").GetComponent<Text>().text = "Platforms in stock: " + remaining_platforms;

        if (Input.GetKeyDown("space"))
        {
            x++;
            if(remaining_platforms>0)
            {
                remaining_platforms--;
            }
            

            //setze jetzige Plattform auf platziert
            if (x > 1 && x <= 11)
            {
                GameObject.Find("Platform_" + (x - 1)).tag = "Placed_platform";
                GameObject.Find("Platform_" + (x - 1)).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }

            //setze nächste Plattform auf aktiv
            if (x <= 10)
            {
                GameObject.Find("Platform_" + x).tag = "Active_platform";
                GameObject.Find("Platform_" + x).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
                GameObject.Find("Platform_" + x).transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x, GameObject.Find("Main Camera").transform.position.y+2, 0);
            }


        }
    }
}

