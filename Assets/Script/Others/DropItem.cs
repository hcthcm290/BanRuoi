using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField]
    GameObject itemPrefab;

    [SerializeField]
    public float chance;

    [SerializeField]
    HealthBase hp;

    private void Start()
    {
        hp.HPChange += OnHPChange;   
    }

    public void RandomDropItem()
    {
        if (itemPrefab == null) return;

        float result = UnityEngine.Random.Range(0.0f, 1.0f);

        if (result <= chance)
        {
            GameObject item = Instantiate(itemPrefab);

            item.transform.position = this.transform.position;
        }
    }

    void OnHPChange(float currentHP)
    {
        if(currentHP == 0)
        {
            RandomDropItem();
        }
    }
}
