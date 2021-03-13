using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCanon : BaseCanon
{
    [SerializeField]
    HomingBullet homingBullet;

    private HomingBullet holdingBullet;

    [SerializeField]
    float interval;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        CreateBullet();
        time = float.PositiveInfinity;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > interval)
        {
            time = float.NegativeInfinity;
            CreateBullet();
        }
    }

    public new void CreateBullet() 
    {
        if (holdingBullet != null) return;
        var bullet = Instantiate(homingBullet, transform);
        bullet.targetFound += OnTargetFound;
        bullet.transform.position = transform.position;
        holdingBullet = bullet;
    }

    void OnTargetFound(GameObject target)
    {
        holdingBullet.targetFound -= OnTargetFound;
        holdingBullet = null;
        time = 0;
    }
}
