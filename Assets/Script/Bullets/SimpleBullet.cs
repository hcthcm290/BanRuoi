using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BaseBullet
{
    [SerializeField]
    public Vector3 Direction;

    [SerializeField]
    float speed;

    public new void Move()
    {
        this.transform.position += speed * Time.deltaTime * Direction.normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
