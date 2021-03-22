﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTripleCanon : BaseCanon
{
    [SerializeField]
    SimpleEnemyBulletMovement bulletPrefab;

    [SerializeField]
    List<Transform> Canons;

    [SerializeField]
    float waveAngleInterval;
    public int numberOfWave;
    int waveIndex;

    bool canShoot;

    [SerializeField]
    float waveInterval;
    float countWaveTime;

    Vector2 baseDirection;

    public void Start()
    {
    }

    public void Update()
    {
        if (canShoot && waveIndex < numberOfWave)
        {
            countWaveTime += Time.deltaTime;

            if (countWaveTime >= waveInterval)
            {
                countWaveTime = 0;
                CreateBullet();
                waveIndex++;

            }
        }

        if (Input.GetKey(KeyCode.Alpha2) && waveIndex >= numberOfWave)
        {
            StartShooting();
        }
    }

    public new void CreateBullet()
    {
        baseDirection = PlayerMovement.playerPosition - this.transform.position;

        baseDirection.Normalize();

        float angle = Random.Range(-waveAngleInterval, waveAngleInterval);
        for (int i = 0; i < Canons.Count; i++)
        {
            SimpleEnemyBulletMovement bullet = Instantiate(bulletPrefab);

            bullet.Direction = Quaternion.Euler(0, 0, angle) * baseDirection;
            bullet.transform.position = Canons[i].position;
            bullet.speed *= 0.8f;
        }

        waveInterval = Random.Range(0.3f, 0.4f);
    }

    public new void StartShooting()
    {
        waveIndex = 0;
        countWaveTime = 0;
        canShoot = true;

        numberOfWave = Random.Range(15, 20);
    }

    public new void StopShooting()
    {
        canShoot = false;
    }
}