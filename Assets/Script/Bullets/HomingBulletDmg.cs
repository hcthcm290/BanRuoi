using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletDmg : MonoBehaviour
{
    [SerializeField]
    float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject != null)
            {
                var enemyHP = collision.gameObject.GetComponent<HealthBase>();

                if(enemyHP != null)
                {
                    enemyHP.TakeDmg(damage);
                }
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
