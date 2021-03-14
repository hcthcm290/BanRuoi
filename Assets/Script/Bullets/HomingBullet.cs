using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : BaseBullet
{
    GameObject target;
    List<GameObject> listTargets;

    public delegate void OnTargetFound(GameObject target);
    public event OnTargetFound targetFound;

    [SerializeField]
    Vector3 initialVelocity;
    Vector3 velocity;

    [SerializeField]
    Vector3 direction;

    [SerializeField]
    float speed;

    bool activated = false;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 1, 0);
        listTargets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateFollowDirection();
    }

    private new void Move()
    {
        /*
        if (target != null)
        {
            Vector3 newVelocity = speed * (target.transform.position - transform.position).normalized;
            velocity += newVelocity * Time.deltaTime;
            velocity = speed * velocity.normalized;
        }

        this.transform.position += velocity * Time.deltaTime;
        */

        listTargets.RemoveAll((x) => { return x == null; });

        if (activated && target == null )
        {
            if(listTargets.Count != 0)
            {
                int r = Random.Range(0, listTargets.Count - 1);

                target = listTargets[r];

                listTargets.RemoveAt(r);
            }
        }

        if (activated && target != null)
        {
            if (time < Time.deltaTime) time = Time.deltaTime;
            this.transform.position = CalculateBezier(Time.deltaTime / time,
                transform.position,
                transform.position + direction*(Vector3.Distance(transform.position, target.transform.position)*0.3f),
                target.transform.position);
            time -= Time.deltaTime;
        }
        else if (activated && target == null)
        {
            this.transform.position += speed * Time.deltaTime * direction;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (collision.gameObject != null)
                {
                    target = collision.gameObject;
                    time = Vector3.Distance(transform.position, target.transform.position)/speed;
                    time = Mathf.Clamp(time, 0.5f, 1.5f);

                    if (!activated)
                    {
                        activated = true;
                        velocity = initialVelocity;
                        targetFound.Invoke(target);
                        transform.parent = null;
                    }
                }
            }
        }

        if(collision.gameObject.tag == "Enemy" && target != null && target != collision.gameObject)
        {
            listTargets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            listTargets.Remove(collision.gameObject);
        }
    }

    private Vector3 CalculateBezier(float t, Vector3 P0, Vector3 P1, Vector3 P2)
    {
        direction = (2 * (1 - t) * (P1 - P0) + 2 * t * (P2 - P1)).normalized;

        var result = Mathf.Pow((1 - t), 2) * P0 + 2 * (1 - t) * t * P1 + Mathf.Pow(t, 2) * P2;
        return result;
    }

    private void RotateFollowDirection()
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);

        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(0, 0, angle - 90);

        this.transform.rotation = q;
    }
}
