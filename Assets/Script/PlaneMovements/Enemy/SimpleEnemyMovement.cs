using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : BaseEnemyMovement
{
    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float speed;

    bool canMove = false;

    private new void Move()
    {
        this.transform.position += speed * Time.deltaTime * direction.normalized;
    }

    public new void StartMoving()
    {
        this.canMove = true;
    }

    public new void StopMoving()
    {
        this.canMove = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
