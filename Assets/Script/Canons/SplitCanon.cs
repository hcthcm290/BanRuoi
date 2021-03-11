using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCanon : SimpleCanon
{
    [SerializeField]
    SimpleBullet bulletPrefab;

    [SerializeField]
    float initialAngle;

    [SerializeField]
    float intervalAngle;

    [SerializeField]
    int numberOfGroup;

    [SerializeField]
    int numberOfBulletPerGroup;

    [SerializeField]
    float intervalAngleGroup;

    public new void CreateBullet()
    {
        if (Time.time - prevShootTime > interval)
        {
            prevShootTime = Time.time;

            float currentAngle = initialAngle + 90;

            for (int i = 0; i < numberOfGroup; i++)
            {
                currentAngle = initialAngle + CalcSthCool(i, intervalAngle) + 90;

                for (int j = 0; j < numberOfBulletPerGroup; j++)
                {
                    float sthCool;

                    if (numberOfBulletPerGroup % 2 == 0)
                    {
                        sthCool = CalcSthCool(j + 1, intervalAngleGroup);
                    }
                    else
                    {
                        sthCool = CalcSthCool(j, intervalAngleGroup);
                    }

                    SimpleBullet bullet = Instantiate(bulletPrefab);
                    bullet.Direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * currentAngle), Mathf.Sin(Mathf.Deg2Rad * currentAngle));
                    bullet.transform.position = transform.position + new Vector3(
                        0.1f * Mathf.Cos(Mathf.Deg2Rad * (currentAngle + sthCool)),
                        0.1f * Mathf.Sin(Mathf.Deg2Rad * (currentAngle + sthCool)));
                }
            }
        }
    }

    private float CalcSthCool(int index, float intervalAngle)
    {
        if (index == 0) return 0;
        if (index % 2 != 0)
        {
            return intervalAngle * (int)((index - 1) / 2 + 1);
        }
        else
        {
            return -intervalAngle * (int)((index - 1) / 2 + 1);
        }
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
