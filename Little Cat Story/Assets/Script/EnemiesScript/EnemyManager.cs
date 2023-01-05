using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float time;
    private float timeTorespawn = 0.6f;

    bool activeEnemies;

    int numberCurrent;


    [SerializeField]
    Player player;

    [SerializeField]
    List<EnemyCollider> enemyList;

    GameObject[] getValueEnemyLenght;

    [SerializeField]
    GameObject[] goldObjects;
    int numbeGoldCurrent;

    [SerializeField]
   List<HitText> hitTextEnemy;
    int hitTextCurrent;

    ManagerGame managerGame;

    [SerializeField]
    Magic[] magicList;
    int numberMagic = 0;

    void Start()
    {
        // hitTextEnemy = GameObject.FindGameObjectsWithTag("HitText");
        goldObjects = GameObject.FindGameObjectsWithTag("Gold");
        getValueEnemyLenght = GameObject.FindGameObjectsWithTag("Enemy");
        managerGame = GameObject.FindGameObjectWithTag("ManagerGame").GetComponent<ManagerGame>();

        for (int i = 0; i < getValueEnemyLenght.Length; i++)
        {
            enemyList.Add(getValueEnemyLenght[i].GetComponent<EnemyCollider>());
            getValueEnemyLenght[i].SetActive(false);
        }

        foreach (var item in goldObjects)
            item.SetActive(false);

        managerGame.UpdateLevel();
        StartEnemiesRespawn();
    }

    public void StartEnemiesRespawn()
    {
        activeEnemies = true;
    }

    private void Update()
    {
        ActiveRespawnEnemies();
    }
    private void ActiveRespawnEnemies()
    {

        if (activeEnemies)
        {
            time += Time.deltaTime;

            if (time >= timeTorespawn)
            {
                if (!enemyList[numberCurrent].isALive && Vector2.Distance(enemyList[numberCurrent].transform.position, player.transform.position) > 11
                    && enemyList[numberCurrent].level <= StatesGame.levelGame)
                {
                    enemyList[numberCurrent].Active();
                  
                }
                if (numberCurrent < enemyList.Count - 1)
                    numberCurrent++;
                else
                    numberCurrent = 0;


                if (numberMagic < magicList.Length)
                { 
                    if (magicList[numberMagic].level <= StatesGame.levelGame)
                    {
                        magicList[numberMagic].Active();
                    }
                }
                numberMagic++;

               time = 0;
            }

        }
    }

    public void TextHitEnemy(Vector2 positionEnemy, int value)
    {
        
        if (hitTextCurrent < hitTextEnemy.Count - 1)
            hitTextCurrent++;
        else
            hitTextCurrent = 0;

        hitTextEnemy[hitTextCurrent].EnabledHit(value);
        hitTextEnemy[hitTextCurrent].transform.position = positionEnemy;
       StartCoroutine(hitTextEnemy[hitTextCurrent].DelayDisable());  //melhorar para desempenho futuramente 
    }

    public void RespawnGold(Vector2 positionEnemy)
    {
        if (numbeGoldCurrent < goldObjects.Length - 1)
            numbeGoldCurrent++;
        else
            numbeGoldCurrent = 0;

        goldObjects[numbeGoldCurrent].transform.position = positionEnemy;
        goldObjects[numbeGoldCurrent].SetActive(true);
    }

    public void StopEnemies()
    {
        CheckLevel();
    }

    private void CheckLevel()
    {
        if (8 >= StatesGame.levelGame)
        {
            timeTorespawn = 0.1F;
        }
        else
        {
            if (7 >= StatesGame.levelGame)
                timeTorespawn = 0.2F;
            else
            {
                if (5 >= StatesGame.levelGame)
                    timeTorespawn = 0.4F;
            }
        }
    }

    public void DeathGame()
    {
         numbeGoldCurrent = 0;
       numberCurrent = 0;
       activeEnemies = false;
       numberMagic = 0;
       foreach (var item in magicList)
           item.Disabled();
       foreach (var item in enemyList)
        item.Disabled();

       

    }
    public void AddXPPlayer(int valueXP)
    {
        player.GetExp(valueXP);
        managerGame.UpdateLevel();
    }
  
}
