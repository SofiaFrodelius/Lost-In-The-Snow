using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour
{
    public int sceneTarget = 0;

    private bool active = false;
    private int fadeTime = 0;
    private float wait = 0.0f;

    public void SceneSwitcher()
    {
        GameObject SceneTransition = GameObject.Find("Scene Transition");
        if (SceneTransition != null)
            fadeTime = SceneTransition.GetComponent<SceneFade>().BeginFade(1);
        active = true;
    }

    private void Update()
    {
        if (active)
        {
            if (fadeTime == 0)
                wait = 1;
            else
                wait += 1000 / fadeTime * Time.deltaTime;
            if (wait >= 1.0f)
            {
                active = false;
                wait = 0.0f;
                SceneManager.LoadScene(sceneTarget);
            }
        }
    }
}