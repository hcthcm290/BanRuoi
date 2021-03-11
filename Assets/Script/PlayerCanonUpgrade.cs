using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanonUpgrade : MonoBehaviour
{
    [SerializeField]
    GameObject[] listCanon;

    
    private int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        SyncCanonWithLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SyncCanonWithLevel()
    {
        for (int i = 0; i < listCanon.Length; i++)
        {
            listCanon[i].SetActive(false);
        }

        for (int i = 0; i < level; i++)
        {
            if (i >= 0 && i < listCanon.Length)
            {
                listCanon[i].SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Eatable Item")
        {
            EatableItem item = collision.gameObject.GetComponent<EatableItem>();

            if(item.Type == "Canon Upgrade")
            {
                this.level++;
                SyncCanonWithLevel();
                Destroy(item.gameObject);
            }
        }
    }
}
