using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerGame : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI textTime;

    [SerializeField]
    TextMeshProUGUI textGold;
    [SerializeField]
    TextMeshProUGUI textLevel;

    float time = 40;

    [SerializeField]
    EnemyManager enemyManager;

   public bool gameactive;

    [SerializeField]
    StoreWindows storeWindows;

    [SerializeField]
    Player player;

    private void Start()
    {
        gameactive = true;
        textGold.text = "" + StatesGame.gold;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0  )
        {
            if (gameactive)
            {
                gameactive = false;
                StartCoroutine(nextLevel());
            }
        }
        else
         textTime.text = "" + (int)time;


        if(!gameactive)
            SelectUpgrade();

    }

    private IEnumerator nextLevel()
    {
        enemyManager.StopEnemies();     
        StatesGame.levelGame++;
        player.PlayerIsActive(false);
        yield return new WaitForSeconds(0.4f);
        storeWindows.Active();    
 
    }
    private void SelectUpgrade()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
                RestartGame();
    }
    public void RestartGame()
    {
        time = 40;
        Time.timeScale = 1;
        gameactive = true;
        player.PlayerIsActive(true);
        storeWindows.Disabled();
        enemyManager.StartEnemiesRespawn();
    }
    public void AddGold(int valueGold)
    {
       StatesGame.gold += valueGold;
        textGold.text =""+ StatesGame.gold;
    }
   public void UpdateGold()
    {
        textGold.text = "" + StatesGame.gold;
    }
    public void UpdateLevel()
    {
        textLevel.text = "" + StatesGame.levelPlayer;
    }

}
