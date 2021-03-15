using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBulletMovement : SimpleBullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateFollowDirection();
    }

    void RotateFollowDirection()
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(Direction.y, Direction.x);

        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(0, 0, angle - 90);

        this.transform.rotation = q;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            if(collision.gameObject.tag == "Player")
            {
                var playerHP = collision.gameObject.GetComponent<HealthBase>();
                if(playerHP != null)
                {
                    playerHP.TakeDmg(damage);
                }
            }
        }
    }
}
