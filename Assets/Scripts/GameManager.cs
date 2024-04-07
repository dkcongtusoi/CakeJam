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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeScene("Jack In The Box");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeScene("Scene 03");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeScene("Scene 04");
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
}
