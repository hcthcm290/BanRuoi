using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBase : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    Transform[] positions;

    [SerializeField]
    float interval;

    [SerializeField]
    float delay;

    bool canSpawn;
    float time;
    int count;

    [SerializeField]
    int max;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canSpawn)
        {
            if (Time.time - time > delay)
                canSpawn = true;
        }

        if(canSpawn)
        {
            if(Time.time - time > interval && count <= max)
            {
                Spawn();
                count++;
                time = Time.time;
            }
        }
    }

    public void Spawn()
    {
        for(int i=0; i<positions.Length; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab);

            enemy.transform.position = positions[i].position;
            HealthBase health = enemy.GetComponent<HealthBase>();

            if(health != null)
            {
                health.maxHP = health.maxHP * (1 + 0.1f + count);
                health.currentHP = health.maxHP;
            }

            
        }
    }
}
