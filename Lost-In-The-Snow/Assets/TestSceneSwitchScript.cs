using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneSwitchScript : MonoBehaviour
{
    public int targetScene = 0;
    public Transform playerPrefab;

    private int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (targetScene != currentScene)
            {
                SceneManager.LoadSceneAsync(targetScene);
                SceneManager.UnloadSceneAsync(currentScene);
            }
        }
	}
}