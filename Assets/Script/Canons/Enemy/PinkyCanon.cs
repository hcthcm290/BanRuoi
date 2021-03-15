using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyCanon: SimpleCanon
{
    public new void CreateBullet()
    {
        if (Time.time - prevShootTime > interval)
        {
            prevShootTime = Time.time;

            GameObject bullet = Instantiate(bulletPreb).gameObject;

            bullet.transform.position = this.transform.position;

            bullet.GetComponent<SimpleEnemyBulletMovement>().Direction = (PlayerMovement.playerPosition - this.transform.position).normalized;
        }
    }

    public new void Start()
    {
        waitFirstTime = 0.0f;
        delayFirstTime = Random.Range(2.0f, 6.0f);
        interval = Random.Range(6.0f, 10.0f);
    }

    public new void Update()
    {
        if (waitFirstTime <= delayFirstTime)
        {
            waitFirstTime += Time.deltaTime;

            if (waitFirstTime > delayFirstTime)
            {
                StartShooting();
            }
        }

        CreateBullet();
    }
}
