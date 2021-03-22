using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;
        if(otherTag == "PlayerBullet" || otherTag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }
    }
}
