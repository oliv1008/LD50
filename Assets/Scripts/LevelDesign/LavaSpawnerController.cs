using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpawnerController : MonoBehaviour
{
    public float startTimeBetweenParticle;
    public float timeBetweenParticle;

    [SerializeField]
    private GameObject lavaParticle;

    void Start()
    {
        timeBetweenParticle = startTimeBetweenParticle;
    }

    void Update()
    {
        timeBetweenParticle -= Time.deltaTime;
        //if()
    }
}
