using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            Destroy(gameObject);
        }
    }
}
