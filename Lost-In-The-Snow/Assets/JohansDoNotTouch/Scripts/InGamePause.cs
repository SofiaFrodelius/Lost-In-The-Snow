using UnityEngine;

public static class InGamePause
{
    private static bool isPaused = false;
	
	public static void TogglePause()
    {
        isPaused = !isPaused;

        CharacterMovement charMove = null;
        ChracterInteract charInteract = null;
        CameraController camCon = null;

        if (isPaused)
        {
            Time.timeScale = 1;
            charMove.CutsceneRelease();
            return;
        }
        charMove.CutsceneLock = true;
        charInteract.CutsceneLock = true;
        camCon.CutsceneLock = true;
        Time.timeScale = 0;
	}
}
