using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonUpgradeItem : EatableItem
{

    // Start is called before the first frame update
    void Start()
    {
        this.Type = "Canon Upgrade";
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
    }
}
