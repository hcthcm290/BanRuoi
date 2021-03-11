using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCanon : BaseCanon
{
    [SerializeField]
    BaseBullet bulletPreb;

    [SerializeField]
    protected float interval;
    protected float prevShootTime = float.PositiveInfinity;

    [SerializeField]
    protected float delayFirstTime;
    protected float waitFirstTime;

    public new virtual void CreateBullet()
    {
        if(Time.time - prevShootTime > interval)
        {
            prevShootTime = Time.time;

            GameObject bullet = Instantiate(bulletPreb).gameObject;

            bullet.transform.position = this.transform.position;
        }
    }

    public new void StartShooting()
    {
        prevShootTime = float.NegativeInfinity;
    }

    public new void StopShooting()
    {
        prevShootTime = float.PositiveInfinity;
    }

    // Start is called before the first frame update
    public void Start()
    {
        waitFirstTime = 0.0f;
    }

    // Update is called once per frame
    public void Update()
    {
        if(waitFirstTime <= delayFirstTime)
        {
            waitFirstTime += Time.deltaTime;

            if(waitFirstTime > delayFirstTime)
            {
                StartShooting();
            }
        }

        CreateBullet();
    }
}
