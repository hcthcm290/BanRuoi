using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNormalCanon : BaseCanon
{
    [SerializeField]
    List<Transform> Canons;

    [SerializeField]
    SimpleEnemyBulletMovement bulletPrefab;

    [SerializeField]
    int numberBulletPerWave;
    int countBullet;

    bool canShoot;

    [SerializeField] 
    float waveInterval;
    [SerializeField]
    float internalWaveInterval;
    float countdown;


    public void Start()
    {
    }

    public void Update()
    {
        if (canShoot)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                CreateBullet();

                countBullet--;
                if(countBullet <= 0)
                {
                    countdown = waveInterval;
                    countBullet = numberBulletPerWave;
                }
                else
                {
                    countdown = internalWaveInterval;
                }
            }
        }
        else if(countBullet > 0 && countBullet < numberBulletPerWave)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                CreateBullet();

                countBullet--;
                if (countBullet <= 0)
                {
                    countdown = waveInterval;
                }
                else
                {
                    countdown = internalWaveInterval;
                }
            }
        }

        if (Input.GetKey(KeyCode.Alpha3) && !canShoot)
        {
            StartShooting();
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            StopShooting();
        }
    }

    public override void CreateBullet()
    {
        for (int i = 0; i < Canons.Count; i++)
        {
            SimpleEnemyBulletMovement bullet = Instantiate(bulletPrefab);

            bullet.Direction = new Vector3(0, -1, 0);
            bullet.transform.position = Canons[i].position;
            bullet.speed *= 1.3f;
        }

    }

    public override void StartShooting()
    {
        countdown = 0;
        canShoot = true;
        countBullet = numberBulletPerWave;
    }

    public override void StopShooting()
    {
        canShoot = false;
    }
}
