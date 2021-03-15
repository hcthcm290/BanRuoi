using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : SpawnEnemyBase
{
    [SerializeField]
    float randomIntervalLow;
    [SerializeField]
    float randomIntervalHigh;
    float currentInterval;
    float time;

    [SerializeField]
    float delay;
    float delayCountTime;

    [SerializeField]
    GameObject LaserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        delayCountTime = 0;
        time = 0;
        currentInterval = Random.Range(randomIntervalLow, randomIntervalHigh);
    }

    // Update is called once per frame
    void Update()
    {
        delayCountTime += Time.deltaTime;
        if (delayCountTime > delay)
        {
            time += Time.deltaTime;
            if (time > currentInterval)
            {
                Spawn();
            }
        }
    }

    public new void Spawn()
    {
        GameObject laser = Instantiate(LaserPrefab);
        laser.transform.position = this.transform.position;

        currentInterval = Random.Range(randomIntervalLow, randomIntervalHigh);
        time = 0;
    }
}
