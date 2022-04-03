using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelButton : MonoBehaviour
{
    private LavaSpawnerController[] spawners;
    private GameObject blocker;

    void Start()
    {
        blocker = GameObject.FindGameObjectWithTag("Blocker");
        spawners = GameObject.FindGameObjectWithTag("LavaSpawner").GetComponentsInChildren<LavaSpawnerController>();
    }

    public void StartLevel()
    {
        blocker.SetActive(false);
        foreach (LavaSpawnerController spawner in spawners)
        {
            spawner.StartSpawning();
        }
    }


}
