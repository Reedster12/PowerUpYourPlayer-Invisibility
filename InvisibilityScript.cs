using UnityEngine;

public class InvisibilityScript : MonoBehaviour
{
    private GameObject player;
    private float tagChangeEndTime;

    public GameObject orb;
    private float orbRespawnTime;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Grab the player GameObject
            player = other.gameObject;

            // Change the tag of the player
            player.tag = "Invisible";

            // Set the tag change end time
            tagChangeEndTime = Time.time + 5f;
            orbRespawnTime = Time.time + 10f;

            // Set the orb to inactive
            orb.SetActive(false);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }


    private void Update()
    {
        if (player != null && Time.time > tagChangeEndTime)
        {
            // Set the player's tag back to "Player"
            player.tag = "Player";
            player = null;
        }

        if (!orb.activeSelf && Time.time > orbRespawnTime)
        {
            // Respawn the orb
            orb.SetActive(true);
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
