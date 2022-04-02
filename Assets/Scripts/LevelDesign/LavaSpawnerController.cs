using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpawnerController : MonoBehaviour
{
    public float startTimeBetweenParticle;
    private float timeBetweenParticle;
    private bool startSpawning = false;

    [SerializeField]
    private GameObject lavaParticle;

    void Start()
    {
        timeBetweenParticle = startTimeBetweenParticle;
    }

    void Update()
    {
        if(startSpawning)
        {
            timeBetweenParticle -= Time.deltaTime;
            if (timeBetweenParticle <= 0)
            {
                timeBetweenParticle = startTimeBetweenParticle;
                Instantiate(lavaParticle, transform.position, Quaternion.identity);
            }
        }
    }

    public void StartSpawning()
    {
        startSpawning = true;
    }
}
