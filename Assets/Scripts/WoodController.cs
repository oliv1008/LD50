using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    [SerializeField]
    private int hp = 3;
    private int currentHp;

    [SerializeField]
    private float startTimeBetweenHpLoss = 1;
    private float timeBetweenHpLoss;

    private Collider2D collider;


    void Start()
    {
        currentHp = hp;
        timeBetweenHpLoss = startTimeBetweenHpLoss;
        collider = GetComponent<Collider2D>();
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
                    Destroy(gameObject);
                }
            }
        }
    }

    private bool HasLavaAround()
    {
        return collider.IsTouchingLayers(LayerMask.GetMask("Lava"));
    }
}
