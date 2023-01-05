using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    Transform playerPosition;

    [SerializeField]
    Rigidbody2D enemyRigdbody2D;

    [SerializeField]
    float velocity = 50;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        MovimenteDefault();
    }

    private void MovimenteDefault()
    {

        if (transform.position.x <= playerPosition.position.x)
        {
            enemyRigdbody2D.velocity = new Vector2(velocity * Time.fixedDeltaTime, enemyRigdbody2D.velocity.y);
          if(!spriteRenderer.flipX && transform.position.x <=( playerPosition.position.x +1))
            spriteRenderer.flipX = true;
        }

        if (transform.position.x > playerPosition.position.x)
        {
            enemyRigdbody2D.velocity = new Vector2(-velocity * Time.fixedDeltaTime, enemyRigdbody2D.velocity.y);
            if (spriteRenderer.flipX && transform.position.x > (playerPosition.position.x + 1))
                spriteRenderer.flipX = false;
        }

        if (transform.position.y >= playerPosition.position.y)
            enemyRigdbody2D.velocity = new Vector2(enemyRigdbody2D.velocity.x, -velocity * Time.fixedDeltaTime);

        if (transform.position.y < playerPosition.position.y)
            enemyRigdbody2D.velocity = new Vector2(enemyRigdbody2D.velocity.x, velocity * Time.fixedDeltaTime);
    }
}
