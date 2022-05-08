using UnityEngine;

public class CoconutProjectileScript : MonoBehaviour
{
    // Public Variables
    public GameObject hitFX;
    public Transform hitFXSpawn;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitFX != null & hitFXSpawn != null)
        {
            GameObject newHitFX = Instantiate(hitFX, hitFXSpawn.position, hitFXSpawn.rotation);

            Destroy(newHitFX, 2f);
        }

        Destroy(gameObject, 0.05f);
    }
}
