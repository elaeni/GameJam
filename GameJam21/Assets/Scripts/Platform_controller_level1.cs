using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_controller_level1 : MonoBehaviour
{
    public int x = 0;
    public int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            x++;

            //setze jetzige Plattform auf platziert
            if(x>1 && x<=20 && x%2==0)
            {
                GameObject.Find("Platform_" + i).tag = "Placed_platform";
                GameObject.Find("Platform_" + i).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                i++;
            }

            //setze nächste Plattform auf aktiv
            if(x<20 && x%2==1)
            {
                GameObject.Find("Platform_" + i).tag = "Active_platform";
                GameObject.Find("Platform_" + i).GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f) ;
            }


        }
    }
}
