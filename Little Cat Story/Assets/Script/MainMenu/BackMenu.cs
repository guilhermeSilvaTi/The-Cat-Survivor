using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenu : MonoBehaviour
{
    [SerializeField]
    GameObject windows;

    [SerializeField]
    GameObject mainmenuWindows;

    [SerializeField]
    AudioSource playSound;
    public void BackToMainMenu()
    {
        playSound.Play();
        windows.SetActive(false);
        mainmenuWindows.SetActive(true);
    }
}
