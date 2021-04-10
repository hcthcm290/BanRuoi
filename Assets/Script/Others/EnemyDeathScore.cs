using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScore : MonoBehaviour
{
    [SerializeField] HealthBase health;
    [SerializeField] float score;

    // Start is called before the first frame update
    void Start()
    {
        health.HPChange += OnHealthUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHealthUpdate(float currentHealth)
    {
        if(currentHealth <= 0)
        {
            PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + score);
        }
    }
}
