using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public float musicVolume = 0;
    public float sfxVolume = 0;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Singleton").Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
