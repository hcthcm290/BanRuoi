using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonUpgradeItem : EatableItem
{
    public float lifeTime;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        this.Type = "Canon Upgrade";
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= lifeTime)
        {
            Destroy(gameObject);
        }
        this.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
    }
}
