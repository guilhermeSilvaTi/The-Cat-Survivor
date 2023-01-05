using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    int life = 100;

    [SerializeField]
    int defense = 5;

    [SerializeField]
   public int level;

    [SerializeField]
    public int xpValue = 10;

    [SerializeField]
    public int damage = 20;

    public bool isALive;

    EnemyManager enemyManager;

    [SerializeField]
    Vector2 positionStat;
    void Start()
    {
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        positionStat = new Vector2(transform.position.x, transform.position.y);
    }

    public IEnumerator Damage(int valueDamage)
    {
        animator.SetInteger("Enemy", 1);
        int result = valueDamage - defense;
        
        life -= result;
     enemyManager.TextHitEnemy(new Vector2(transform.position.x-1, transform.position.y), result);

        if (life <= 0)
        {
            isALive = false;
            animator.SetInteger("Enemy", 2);
            enemyManager.AddXPPlayer(xpValue);
            yield return new WaitForSeconds(0.2f);
            enemyManager.RespawnGold(new Vector2(transform.position.x, transform.position.y));
            Disabled();
        }
        else
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetInteger("Enemy", 0);
        }
    }

    public void Disabled()
    {
        isALive = false;
        life = 100;
        animator.SetInteger("Enemy", 0);
        transform.position = new Vector2(positionStat.x, positionStat.y);
        this.gameObject.SetActive(false);
    }

    public void Active()
    {
        life = 100;     
        isALive = true;
        animator.SetInteger("Enemy", 0);
        this.gameObject.SetActive(true);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Shoot") && isALive)
        {
            
          StartCoroutine( Damage(col.gameObject.GetComponent<Shoot>().damage));
           
        }
    }
}
