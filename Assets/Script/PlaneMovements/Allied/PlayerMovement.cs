using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 playerPosition;

    [SerializeField]
    CircleCollider2D TouchZone;
    bool canMove;
    Vector3 offset;
    bool hide = false;

    [SerializeField] HealthBase health;


    // Start is called before the first frame update
    void Start()
    {
        health.HPChange += OnHPChange;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanMove();
        Move();
        
        playerPosition = transform.position;

        if (hide)
        {
            var pos = transform.position;

            pos.z = -10;
            transform.position = pos;
        }

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

    private void OnDestroy()
    {
        //PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.AutomatedAction);
    }
    
    void OnHPChange(float currentHP)
    {
        if(currentHP == 0)
        {
            TextDialog._ins.content = "You Lose";
            TextDialog._ins.Show();
            hide = true;
            StartCoroutine("EndGame");

        }
    }

    IEnumerator EndGame()
    {        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);

        SceneManager.LoadScene("MenuScene");
    }
}
