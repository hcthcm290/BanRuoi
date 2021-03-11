using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : SimpleBullet
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HealthBase enemyHealth = collision.gameObject.GetComponent<HealthBase>();

            if(enemyHealth != null)
            {
                enemyHealth.TakeDmg(damage);
            }

            Destroy(this.gameObject);
        }
    }

    private void RotateFollowDirection()
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(Direction.y, Direction.x);

        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(0, 0, angle - 90);

        this.transform.rotation = q;
    }
}
