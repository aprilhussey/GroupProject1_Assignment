using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumplandsound : MonoBehaviour
{

    public AudioSource audioPlayer;

    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            audioPlayer.Play();
        }
    }
};
