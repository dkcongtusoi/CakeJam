using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    #endregion

    public string secretIngredient;
    public string requiredItem;
    public int prize;
    public bool hasRequiredItem;
    bool isInDevMode = false;

    private void Update()
    {
        if (isInDevMode)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                LoadNextScene();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                LoadPreviousScene();
            }

            //Restart
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
        
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F12))
        {
            isInDevMode = !isInDevMode;
            Debug.Log("Dev Mode Is Active: " + isInDevMode);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        int allScene = SceneManager.sceneCountInBuildSettings;
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < allScene - 1)
            SceneManager.LoadScene(currentScene + 1);
        else
            print("Its last scene");
    }

    public void LoadPreviousScene()
    {
        int allScene = SceneManager.sceneCountInBuildSettings;
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene > 0)
            SceneManager.LoadScene(currentScene - 1);
        else
            print("Its last scene");
    }
}
