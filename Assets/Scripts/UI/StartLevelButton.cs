using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartLevelButton : MonoBehaviour
{
    private LavaSpawnerController[] spawners;
    private GameObject blocker;

    public UnityEvent start = new UnityEvent();

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
        start.Invoke();
    }


}
