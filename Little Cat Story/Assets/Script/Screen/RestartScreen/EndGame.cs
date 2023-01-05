using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject windowsEndGame;
    [SerializeField]
    LoadGame loadGame;

    public IEnumerator LevelIsEnd()
    {
        windowsEndGame.SetActive(true);
        yield return new WaitForSeconds(2.2f);      
        loadGame.GameOver();
    }
}
