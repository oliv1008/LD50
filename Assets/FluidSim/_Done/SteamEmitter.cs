using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamEmitter : MonoBehaviour
{
    [SerializeField]
    private GameObject steamParticle;

    public void EmitSteam()
    {
        Instantiate(steamParticle, transform.position, Quaternion.identity);
    }
}
