using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class CoconutShootingScript : MonoBehaviour
{
    // Public Variables
    [Header("Projectile Properties")]
    public GameObject coconut;                  // Prefab of the Coconut sprite that has a collider and rigidbody2d component on it
    public Transform coconutSpawn;              // An empty game object that is used as the Coconut's spawn location
    public ParticleSystem coconutShootingFX;    // A particle effect that is instantiated on firing
    public AudioSource coconutShootingSFX;      // Sound effect that is played when shooting
    public float coconutVelocity = 100f;        // The velocity/force of the Coconut
    public int coconutAmount;                   // integer amount of Coconuts that the player has, amount increases with seperate script and decreases when a Coconut is shot

    // HUD Variables
    [Header("HUD & UI Elements")]
    public TextMeshProUGUI coconutAmountDisplay;

    // Shooting Function
    public void ShootCoconut()
    {
        if (coconutAmount > 0)
        {
            if (coconutShootingFX != null)
            {
                coconutShootingFX.Play();
            }

            if (coconutShootingSFX != null)
            {
                coconutShootingSFX.Play();
            }

            GameObject coconutProjectile = Instantiate(coconut, coconutSpawn.position, coconutSpawn.rotation);
            coconutProjectile.GetComponent<Rigidbody2D>().AddForce(transform.forward * coconutVelocity, ForceMode2D.Impulse);

            coconutAmount--;
        }
    }
}
