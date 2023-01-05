using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    int gold = 10;

    [SerializeField]
    ManagerGame manager;

    Transform playerPosition;

    float velocity = 8;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
    }

    private void Update()
    {
        MovimenteDefault();
    }
    private void MovimenteDefault()
    {
       if ( Vector2.Distance(transform.position, playerPosition.position) < 5 && StatesGame.hability[1] == Hability.Magnet)
        {
            if (transform.position.x <= playerPosition.position.x)
                transform.Translate(Vector2.right * velocity * Time.deltaTime);

            if (transform.position.x > playerPosition.position.x)
                transform.Translate(Vector2.left * velocity * Time.deltaTime);

            if (transform.position.y >= playerPosition.position.y)
                transform.Translate(Vector2.down * velocity * Time.deltaTime);

            if (transform.position.y < playerPosition.position.y)
                transform.Translate(Vector2.up * velocity * Time.deltaTime);
        }

    }

    public void ActiveGold()
    {
        this.gameObject.SetActive(true);
    }

    private void DisableGold()
    {
        manager.AddGold(gold);
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ///verificar
        if (col.gameObject.CompareTag("Player"))
        {
            DisableGold();
        }

    }
}
