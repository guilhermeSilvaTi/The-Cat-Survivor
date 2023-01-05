using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    Player player;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {      
            int valueDamage = coll.gameObject.GetComponent<EnemyCollider>().damage;
            player.GetDamage(valueDamage);
        }

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Magic"))
        {
            int valueDamage = collision.gameObject.GetComponent<Magic>().damage;
            player.GetDamage(valueDamage);
            StartCoroutine(player.GetFreeze());
        }
    }
}
