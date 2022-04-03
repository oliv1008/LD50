using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZoneScript : MonoBehaviour
{
    public int hpLeft = 10;
    public UnityEvent dieEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "LavaParticle")
        {
            hpLeft -= 1;
            if (hpLeft == 0)
            {
                dieEvent.Invoke();
            }
        }

        Object.Destroy(collision.gameObject);
    }
}
