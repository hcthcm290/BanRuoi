using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGUI : MonoBehaviour
{
    [SerializeField]
    HealthBase health;

    [SerializeField]
    bool visibleWhenFull;

    [SerializeField]
    GameObject healthBar;

    float prevHP;

    Vector3 InitScale;

    // Start is called before the first frame update
    void Start()
    {
        InitScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!visibleWhenFull)
        {
            if (health.currentHP == health.maxHP && prevHP < health.maxHP)
            {
                this.transform.localScale = new Vector3(0, 0, 0);
            }
            else if(health.currentHP < health.maxHP && prevHP == health.maxHP)
            {
                this.transform.localScale = InitScale;
            }
        }

        var scale = healthBar.transform.localScale;

        scale.x = health.currentHP / health.maxHP;

        healthBar.transform.localScale = scale;

        prevHP = health.currentHP;
    }
}
