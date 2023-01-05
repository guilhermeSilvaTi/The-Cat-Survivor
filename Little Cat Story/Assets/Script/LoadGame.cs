using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    bool startLoad;
    static AsyncOperation operation;
    [SerializeField]
    Vector2 positionstart;

    [SerializeField]
    float positionXEnd;

    [SerializeField]
    bool IsLevel;

    [SerializeField]
    float velocity = 2;
    private void Start()
    {
        transform.position = new Vector2(positionstart.x, positionstart.y);

        if (IsLevel)
            StartCoroutine(IsLevelGame());

    }
    private IEnumerator IsLevelGame()
    {
       
            while (transform.position.x <= positionXEnd)
            {
                transform.Translate(Vector2.right * velocity* Time.deltaTime);
                yield return new WaitForSeconds(0.01f);
            }     
               IsLevel = false;
       
    }
    public IEnumerator LoadNewLevel(string sceneLoad)
    {
        Time.timeScale = 1;
        while (transform.position.x <= positionXEnd)
        {
            transform.Translate(Vector2.right * velocity*Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        if (!startLoad)
        {
            startLoad = true;
            StartCoroutine(LoadAsinchronously(sceneLoad));
        }

        //  loadActive = true;
    }
    public void GameOver()
    {
        StatesGame.ResetGame();
        StartCoroutine(LoadAsinchronously("MainMenu"));
    }

    IEnumerator LoadAsinchronously(string sceneLoad)
    {
        operation = SceneManager.LoadSceneAsync(sceneLoad);
        try
        {// loadBar.transform.position = new Vector2(mainCamera.transform.position.x + 2, mainCamera.transform.position.y - 2);
        }
        catch { }

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            // loadBar.fillAmount = progress;
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (operation != null)
        {
            return operation.progress;
        }
        else
        {
            return 1f;
        }
    }
}
