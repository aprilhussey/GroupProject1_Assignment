using UnityEngine;

public class CoconutPickUpScript : MonoBehaviour
{
    // Refernce Player
    CoconutShootingScript coconutShootingScript;
    public GameObject player;
    
    // Public Variables
    public GameObject pickUpFX;
    public Transform pickUpFXSpawn;

    private void Awake()
    {
        coconutShootingScript = player.GetComponent<CoconutShootingScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coconutShootingScript.coconutAmount++;

            if (pickUpFX != null & pickUpFXSpawn != null)
            {
                GameObject newPickUpFX = Instantiate(pickUpFX, pickUpFXSpawn.position, pickUpFXSpawn.rotation);

                Destroy(newPickUpFX, 2f);
            }

            Destroy(gameObject, 0.5f);
        }
    }
}
