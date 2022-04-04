using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZoneScript : MonoBehaviour
{
    public int hpMax = 10;
    private int hpLeft;
    public static UnityEvent dieEvent = new UnityEvent();

    private HeartController heartController;

    void Start()
    {
        heartController = GameObject.FindGameObjectWithTag("Heart").GetComponent<HeartController>();
        hpLeft = hpMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            hpLeft -= 1;
            heartController.SetRatio(hpLeft/(float)hpMax);
            if (hpLeft == 0)
            {
                dieEvent.Invoke();
            }
        }

        Object.Destroy(collision.gameObject);
    }
}
