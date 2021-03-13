using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPinky : SpawnEnemyBase
{
    [SerializeField]
    GameObject PinkyPrefab;

    [SerializeField]
    GameObject test;

    Vector3 spawnPosition;

    int numberOfEnemy;
    int countNumberSpawned;

    [SerializeField]
    float interval;
    float intervalCountTime;

    Vector3[] targets;

    [SerializeField]
    new Camera camera;

    List<GameObject> listPinkySpawned;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (countNumberSpawned < numberOfEnemy)
        {
            intervalCountTime += Time.deltaTime;

            if (intervalCountTime >= interval)
            {
                intervalCountTime = 0;
                countNumberSpawned++;

                GameObject enemy = Instantiate(PinkyPrefab);

                enemy.transform.position = spawnPosition;
                enemy.GetComponent<PinkyMovement>().targets = targets;

                listPinkySpawned.Add(enemy);
            }
        }

        if(countNumberSpawned == numberOfEnemy)
        {
            bool Done = true;
            for(int i=0; i<listPinkySpawned.Count; i++)
            {
                if (listPinkySpawned[i] != null)
                    Done = false;
            }
            if (Done)
                Destroy(gameObject);
        }
    }

    public new void Spawn()
    {
        float randomX = Random.Range(-3.0f, 3.0f);

        spawnPosition = new Vector3(randomX, 5.1f, 0);

        numberOfEnemy = Random.Range(4, 7);

        intervalCountTime = float.PositiveInfinity;

        countNumberSpawned = 0;

        RandomTargets();

        listPinkySpawned = new List<GameObject>();
    }

    public void RandomTargets()
    {
        int ntarget = Random.Range(3, 5);
        targets = new Vector3[ntarget];

        for(int i=0; i<ntarget; i++)
        {
            float x = Random.Range(-2.5f, 2.5f);
            float y;
            if(i < ntarget - 1)
            {
                y = Random.Range(-3.0f, 4.0f);
            }
            else
            {
                y = -6f;
            }

            targets[i] = new Vector3(x, y, 0);
        }
    }
}
