using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessBullet : BaseBullet
{
    public Vector3 direction;

    [SerializeField] 
    float speed;

    [SerializeField]
    float flyTime;
    float startFlyingTime;

    [SerializeField]
    AnimationCurve explosionSizeOvertime;
    bool exploded = false;
    float explodeTime;

    List<GameObject> listEnemyInside;

    // Start is called before the first frame update
    void Start()
    {
        startFlyingTime = Time.time;
        listEnemyInside = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Time.time - startFlyingTime >= flyTime || exploded)
        {
            Explode();
        }

        if(this.transform.localScale.x <= 0)
        {
            Destroy(this.gameObject);
        }

        DealDamage();
    }

    private new void Move()
    {
        if(Time.time - startFlyingTime < flyTime && !exploded)
        {
            this.transform.position += speed * Time.deltaTime * direction;
        }
    }

    private void Explode()
    {
        if (!exploded)
        {
            exploded = true;
            explodeTime = Time.time;
        }

        Vector3 scale = this.transform.localScale;
        float scaleValue = explosionSizeOvertime.Evaluate(Time.time - explodeTime);

        scale.x = scale.y = scaleValue;

        this.transform.localScale = scale;
    }

    private void DealDamage()
    {
        foreach(var enemy in listEnemyInside)
        {
            if (enemy != null)
            {
                HealthBase health = enemy.GetComponent<HealthBase>();

                if (health != null)
                {
                    health.TakeDmg(damage * Time.deltaTime);
                }
            }
        }

        listEnemyInside.RemoveAll(x => { return x == null; });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();

        string colTag = collision.gameObject.tag;

        if(colTag == "Enemy")
        {
            //add vao

            if (collision.gameObject != null)
            {
                listEnemyInside.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string colTag = collision.gameObject.tag;

        if (colTag == "Enemy")
        {
            if (collision.gameObject != null)
            {
                listEnemyInside.Remove(collision.gameObject);
            }
        }
    }
}
