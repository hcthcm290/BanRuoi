using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CircleCollider2D TouchZone;
    bool canMove;
    Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanMove();
        Move();
    }

    bool CheckCanMove()
    {
        bool previousCanMove = canMove;

        if(previousCanMove == true)
        {
            canMove = Input.GetMouseButton(0);
            return canMove;
        }

        //canMove = TouchZone.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetMouseButton(0);

        canMove = Input.GetMouseButton(0);

        if(canMove == true && previousCanMove == false)
        {
            offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        return canMove;
    }

    void Move()
    {
        if(canMove)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
