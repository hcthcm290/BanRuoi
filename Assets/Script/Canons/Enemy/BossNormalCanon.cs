using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    List<Transform> Canons;

    [SerializeField]
    SimpleEnemyBulletMovement bulletPrefab;

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

    public new void CreateBullet()
    {
        baseDirection = PlayerMovement.playerPosition - this.transform.position;

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

    public new void StartShooting()
    {
        waveIndex = 0;
        countWaveTime = 0;
        canShoot = true;
    }

    public new void StopShooting()
    {
        canShoot = false;
    }
}
