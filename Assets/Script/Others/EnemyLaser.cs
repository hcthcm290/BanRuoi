using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    Transform SizeController;

    HealthBase playerHP;

    [SerializeField]
    float DPS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP != null)
        {
            playerHP.TakeDmg(DPS * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            if(collision.gameObject.tag == "Player")
            {
                playerHP = collision.gameObject.GetComponent<HealthBase>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            if(collision.gameObject.tag == "Player")
            {
                playerHP = null;
            }
        }
    }
}
