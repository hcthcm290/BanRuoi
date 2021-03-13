using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    SpawnEnemyBase[] listSpawner;

    SpawnEnemyBase currentSpawner;

    int totalWaveCount;

    // Start is called before the first frame update
    void Start()
    {
        totalWaveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(totalWaveCount < 10 && currentSpawner == null)
        {
            totalWaveCount++;

            int random = Random.Range(0, listSpawner.Length - 1);

            currentSpawner = Instantiate(listSpawner[random]);
        }
    }
}
