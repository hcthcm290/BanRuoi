using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyMovement : BaseEnemyMovement
{
    public Vector3[] targets;
    public int currentTargetIndex = 0;


    public float timeout;
    float countTimeout;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float speed;

    public float turnRate;

    bool canMove = true;

    bool locked = false;

    protected new void Move() 
    {
        if (!canMove) return;

        UpdateCurrentTarget();
        UpdateDirection();
        rotateFollowDirection();

        this.transform.position += this.speed * Time.deltaTime * direction;
    }


    public new void StartMoving() 
    {
        canMove = true;

        countTimeout = 0;
    }
    public new void StopMoving() 
    {
        canMove = false;
    }

    /// <summary>
    /// Rotate the direction into target
    /// </summary>
    private void UpdateDirection()
    {
        float directionAngle = Mathf.Rad2Deg * Mathf.Atan2(direction.normalized.y, direction.normalized.x);
        Vector3 targetDirection = (targets[currentTargetIndex] - transform.position).normalized;
        float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(targetDirection.y, targetDirection.x);

        float angle = directionAngle - targetAngle;

        if(locked)
        {
            direction = (targets[currentTargetIndex] - transform.position).normalized;
        }
        else
        {
            if (Mathf.Abs(angle) <= turnRate * Time.deltaTime)
            {
                direction = (targets[currentTargetIndex] - transform.position).normalized;
                locked = true;
            }
            else
            {
                float rotateAngle = turnRate * Time.deltaTime;

                if (angle > 0 || angle < -180)
                    rotateAngle *= -1;

                direction = Quaternion.Euler(0, 0, rotateAngle) * direction;
            }
        }
    }

    private void rotateFollowDirection()
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);

        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(0, 0, angle - 90);

        this.transform.rotation = q;
    }

    private void UpdateCurrentTarget()
    {
        countTimeout += Time.deltaTime;

        if (countTimeout > timeout)
        {
            countTimeout = 0;
            currentTargetIndex++;

            currentTargetIndex = Mathf.Clamp(currentTargetIndex, 0, targets.Length - 1);
            locked = false;
        }

        if(Vector3.Distance(this.transform.position, targets[currentTargetIndex]) < 0.04f)
        {
            if(currentTargetIndex == targets.Length - 1)
            {
                Destroy(gameObject);
            }

            countTimeout = 0;
            currentTargetIndex++;

            currentTargetIndex = Mathf.Clamp(currentTargetIndex, 0, targets.Length - 1);
            locked = false;
        }
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
