using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    public Texture2D fadeTexture;
    public int fadeTime = 1000;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = -1;

    private void OnGUI()
    {
        if (fadeTime == 0)
            alpha = fadeDirection;
        else
            alpha += fadeDirection * 1000 / fadeTime * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public int BeginFade(int direction)
    {
        fadeDirection = direction;
        return fadeTime;
    }
}
