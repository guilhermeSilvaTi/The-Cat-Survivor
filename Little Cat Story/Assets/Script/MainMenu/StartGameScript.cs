using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    [SerializeField]
    Transform mainCameraTransforme;

    [SerializeField]
    LoadGame loadGame;

    [SerializeField]
    string nameLevelGame = "Level";

    [SerializeField]
    AudioSource playSound;
    public void CallLevel()
    {
        playSound.Play();
      StartCoroutine( loadGame.LoadNewLevel(nameLevelGame));
    }

}
