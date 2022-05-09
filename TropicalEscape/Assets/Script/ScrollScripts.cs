using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScripts : MonoBehaviour
{

    public float scrollSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset % 1, 0);
    }
}
