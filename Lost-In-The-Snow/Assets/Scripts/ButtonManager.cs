using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void StartBtn(string SceneName)
    {
        SceneManager.LoadScene(2);
    }

    public void OptionsBtn(string SceneName)
    {
        SceneManager.LoadScene(0);
    }

    public void BackBtn(string SceneName)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ExitBtn()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
