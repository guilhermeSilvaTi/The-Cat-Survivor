using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    int valueSelect;

    [SerializeField]
    GameObject screenPause;

    bool startMenuPause;

    [SerializeField]
    LoadGame loadGame;

    [SerializeField]
    TextMeshProUGUI[] textSelect;

    [SerializeField]
    Player player;
    void Start()
    {
        
    }

    void Update()
    {
        KeyboardControll();
    }

    private void KeyboardControll()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            CallScreenPause();
        }

        if (startMenuPause)
        {
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && valueSelect < textSelect.Length-1)
            {
                textSelect[valueSelect].color = Color.gray;
                valueSelect++;
                textSelect[valueSelect].color = Color.white;
            }

            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && valueSelect >0)
            {
                textSelect[valueSelect].color = Color.gray;
                valueSelect--;
                textSelect[valueSelect].color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                CheckValueSelect(valueSelect);
            }
        }
    }

    private void CallScreenPause()
    {
        Time.timeScale = 0;
        textSelect[1].color = Color.gray;
        textSelect[0].color = Color.white;
        player.PlayerIsActive(false);
        valueSelect = 0;
        screenPause.SetActive(true);
        startMenuPause = true;
    }

    private void CheckValueSelect(int value)
    {
       switch(value)
        {
            case 0:
                {
                    Time.timeScale = 1;
                    player.PlayerIsActive(true);
                    startMenuPause = false;
                    screenPause.SetActive(false);
                    break;
                }
            case 1:
                {
                   
                   loadGame.GameOver();
                    break;
                }
        }
    }
}
