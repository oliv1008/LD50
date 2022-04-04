using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    [SerializeField]
    private float hp = 3;
    private float currentHp;
    private float percentHp = 1;

    [SerializeField]
    private float startTimeBetweenHpLoss = 1;
    private float timeBetweenHpLoss;

    [SerializeField]
    private Sprite fullHp;
    [SerializeField]
    private Sprite nearlyFullHp;
    [SerializeField]
    private Sprite halfHp;
    [SerializeField]
    private Sprite nearlyDestroyed;
    private AudioSource destroyedSound;

    private Collider2D woodCollider;
    private SpriteRenderer spriteComponent;

    [SerializeField] private GameObject woodParticleEffect;
    [SerializeField] private Transform rightPosition;
    [SerializeField] private Transform leftPosition;


    void Start()
    {
        currentHp = hp;
        timeBetweenHpLoss = startTimeBetweenHpLoss;
        woodCollider = GetComponent<Collider2D>();
        spriteComponent = GetComponent<SpriteRenderer>();
        destroyedSound = GameObject.FindGameObjectWithTag("DestroyedWoodSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        timeBetweenHpLoss -= Time.deltaTime;
        if (timeBetweenHpLoss <= 0)
        {
            if (HasLavaAround())
            {
                timeBetweenHpLoss = startTimeBetweenHpLoss;
                currentHp -= 1;
                if (currentHp <= 0)
                {
                    destroyedSound.Play();
                    Instantiate(woodParticleEffect, transform.position, Quaternion.identity);
                    Instantiate(woodParticleEffect, rightPosition.position, Quaternion.identity);
                    Instantiate(woodParticleEffect, leftPosition.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                percentHp = currentHp / hp;

                if(percentHp > 0.75f)
                {
                    spriteComponent.sprite = fullHp;
                }
                else if (percentHp <= 0.75f && percentHp > 0.5f)
                {
                    spriteComponent.sprite = nearlyFullHp;
                }
                else if (percentHp <= 0.5f && percentHp > 0.25f)
                {
                    spriteComponent.sprite = halfHp;
                }
                else
                {
                    spriteComponent.sprite = nearlyDestroyed;
                }

            }
        }
    }

    private bool HasLavaAround()
    {
        return woodCollider.IsTouchingLayers(LayerMask.GetMask("Lava"));
    }
}
