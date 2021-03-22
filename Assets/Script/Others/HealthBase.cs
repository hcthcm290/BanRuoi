using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

    public delegate void OnHPChange(float currentHP);
    public event OnHPChange HPChange;

    public void TakeDmg(float value)
    {
        currentHP -= value;

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if(HPChange != null)
        {
            HPChange.Invoke(currentHP);
        }
    }

    public void Heal(float value)
    {
        currentHP += value;

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        HPChange.Invoke(currentHP);
    }

    private void Update()
    {
        if (currentHP == 0)
            Destroy(this.gameObject);
    }
}
