using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnemy : MonoBehaviour
{
    [SerializeField]
    EnemyCollider enemyCollider;

    float time;

    float timeShoot = 3.4f;

    [SerializeField]
    GameObject magic;
    [SerializeField]
    Animator magicAnimator;

    [SerializeField]
    Transform playerTransforme;

    void Update()
    {
        if(enemyCollider.isALive)
        {
            time += Time.deltaTime;

            if (time >= timeShoot  && Vector2.Distance(transform.position, playerTransforme.position) < 8)
            {
                CallingMagic();
                time = 0;
            }
        }     
    }

    private void CallingMagic()
    {
        magic.transform.position = new Vector2(playerTransforme.position.x, playerTransforme.position.y);
        magic.SetActive(true);
        magicAnimator.Rebind();
        magicAnimator.Update(0f);
       
    }

}
