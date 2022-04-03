using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamEmitter : MonoBehaviour
{
    [SerializeField]
    private GameObject steamParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            // On supprime l'eau, à terme peut être faire un effet de particule
            collision.gameObject.GetComponent<LavaTurningIntoObsidian>().TurnIntoObsidian();
            Instantiate(steamParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
