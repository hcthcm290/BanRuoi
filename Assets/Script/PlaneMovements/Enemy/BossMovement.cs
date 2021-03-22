using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : BaseEnemyMovement
{
    bool canMove = false;

    Vector3 direction;

    [SerializeField]
    float speed;

    [SerializeField]
    float mix_x;

    [SerializeField]
    float max_x;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(-1, 0, 0);
        StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Move();
        }
    }


    protected new void Move() 
    {
        this.transform.position += speed * Time.deltaTime * direction;

        if(this.transform.position.x < mix_x || this.transform.position.x > max_x)
        {
            direction.x *= -1;
        }
    }

    public new void StartMoving() 
    {
        canMove = true;
    }

    public new void StopMoving() 
    {
        canMove = false;
    }
}
