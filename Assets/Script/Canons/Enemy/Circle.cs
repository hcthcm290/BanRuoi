using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : BaseCanon
{
    [SerializeField]
    SimpleEnemyBulletMovement[] listBullets;
    int indexCurrentBullet;

    [SerializeField]
    float waveAngleInterval;
    public int numberOfWave;
    public int numberBulletPerWave;
    int waveIndex;

    bool canShoot;

    [SerializeField]
    float waveInterval;
    float countWaveTime;

    Vector2 baseDirection;

    public void Start()
    {
        //StartShooting();
    }

    public void Update()
    {
        if(canShoot && waveIndex < numberOfWave)
        {
            countWaveTime += Time.deltaTime;

            if(countWaveTime >= waveInterval)
            {
                countWaveTime = 0;
                CreateBullet();
                waveIndex++;

                baseDirection = Quaternion.Euler(0, 0, waveAngleInterval) * baseDirection;
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            StartShooting();
        }
    }

    public new void CreateBullet() 
    {
        float angle = 360 / numberBulletPerWave;
        for(int i=0; i<numberBulletPerWave; i++)
        {
            SimpleEnemyBulletMovement bullet = Instantiate(listBullets[indexCurrentBullet]);

            bullet.Direction = Quaternion.Euler(0, 0, i * angle) * baseDirection;
            bullet.transform.position = transform.position;
            
        }
    }

    public new void StartShooting() 
    {
        waveIndex = 0;
        countWaveTime = 0;
        canShoot = true;

        numberOfWave = Random.Range(25, 40);
        waveAngleInterval = Random.Range(10, 14);
        numberBulletPerWave = Random.Range(15, 18);
        waveInterval = Random.Range(0.12f, 0.14f);


        baseDirection.x = Random.Range(-1.0f, 1.0f);
        baseDirection.y = Random.Range(-1.0f, 1.0f);

        baseDirection.Normalize();
    }

    public new void StopShooting() 
    {
        canShoot = false;
    }
}
