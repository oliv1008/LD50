using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTurningIntoObsidian : MonoBehaviour
{
    [SerializeField]
    private GameObject obsidianParticle;

    public void TurnIntoObsidian()
    {
        gameObject.layer = 9;
        gameObject.tag = "Untagged";
        gameObject.GetComponent<CircleCollider2D>().sharedMaterial = obsidianParticle.GetComponent<CircleCollider2D>().sharedMaterial;
        gameObject.GetComponent<Rigidbody2D>().mass = obsidianParticle.GetComponent<Rigidbody2D>().mass;
        gameObject.GetComponent<Rigidbody2D>().angularDrag = obsidianParticle.GetComponent<Rigidbody2D>().angularDrag;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = obsidianParticle.GetComponent<Rigidbody2D>().gravityScale;
        gameObject.GetComponent<Rigidbody2D>().drag = obsidianParticle.GetComponent<Rigidbody2D>().drag;
        gameObject.GetComponent<SpriteRenderer>().sprite = obsidianParticle.GetComponent<SpriteRenderer>().sprite;
    }
}
