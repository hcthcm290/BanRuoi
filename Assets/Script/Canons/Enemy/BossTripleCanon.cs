using System.Collections;
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

    Vector3 prevPlayerPosition;

    [SerializeField]
    float interpolateFactor;

    public void Start()
    {
        waveIndex = numberOfWave;
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

        prevPlayerPosition = PlayerMovement.playerPosition;
    }

    public override void CreateBullet()
    {
        baseDirection = PlayerMovement.playerPosition + interpolateFactor*(PlayerMovement.playerPosition - prevPlayerPosition) - this.transform.position;

        baseDirection.Normalize();

        for (int i = 0; i < Canons.Count; i++)
        {
            SimpleEnemyBulletMovement bullet = Instantiate(bulletPrefab);

            float angle = Random.Range(-waveAngleInterval, waveAngleInterval);

            bullet.Direction = Quaternion.Euler(0, 0, angle) * baseDirection;
            bullet.transform.position = Canons[i].position;
            bullet.speed *= 0.8f;
        }

        waveInterval = Random.Range(0.3f, 0.4f);
    }

    public override void StartShooting()
    {
        waveIndex = 0;
        countWaveTime = 0;
        canShoot = true;
    }

    public override void StopShooting()
    {
        canShoot = false;
    }
}
