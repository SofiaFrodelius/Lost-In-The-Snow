using UnityEngine;

public static class InGamePause {
    private static bool isPaused = false;
	

	public static void TogglePause () {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0;
	}
	
}
