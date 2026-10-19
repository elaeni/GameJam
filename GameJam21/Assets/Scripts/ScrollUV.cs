using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>(); // get renderer of this Object
        Material mat = mr.materials[0] ; // grab first Material of this Object
        Vector2 offset = mat.mainTextureOffset; // get Offset of Texture

        //offset.x += Time.deltaTime/10;
        offset.x = transform.position.x;
        mat.mainTextureOffset = offset;
    }
}
