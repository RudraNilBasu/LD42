﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    [SerializeField]
    GameObject[] spawnObjects;
    float spawnMin = 1f;
    float spawnMax = 2f;

    bool SHOW_LOG = true;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Logger.LOG("Spawner: Spawning a random object", SHOW_LOG);
        Instantiate(
                spawnObjects[Random.Range(0, spawnObjects.GetLength(0))],
                transform.position,
                Quaternion.identity
                );
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
