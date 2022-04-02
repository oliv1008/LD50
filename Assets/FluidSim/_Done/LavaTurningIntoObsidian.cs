using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTurningIntoObsidian : MonoBehaviour
{
    [SerializeField]
    private GameObject obsidianParticle;

    private bool hasTurnedIntoObsidian = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasTurnedIntoObsidian)
        {
            if (collision.CompareTag("Water"))
            {
                // On supprime l'eau, à terme peut être faire un effet de particule
                collision.gameObject.GetComponent<SteamEmitter>().EmitSteam();
                Destroy(collision.gameObject);

                gameObject.layer = 9;
                gameObject.GetComponent<CircleCollider2D>().sharedMaterial = obsidianParticle.GetComponent<CircleCollider2D>().sharedMaterial;
                gameObject.GetComponent<Rigidbody2D>().mass = obsidianParticle.GetComponent<Rigidbody2D>().mass;
                gameObject.GetComponent<Rigidbody2D>().angularDrag = obsidianParticle.GetComponent<Rigidbody2D>().angularDrag;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = obsidianParticle.GetComponent<Rigidbody2D>().gravityScale;
                gameObject.GetComponent<Rigidbody2D>().drag = obsidianParticle.GetComponent<Rigidbody2D>().drag;

                hasTurnedIntoObsidian = true;
            }
        }
    }
}
