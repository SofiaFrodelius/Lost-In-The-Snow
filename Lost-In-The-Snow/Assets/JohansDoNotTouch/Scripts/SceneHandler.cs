using UnityEngine.SceneManagement;

public static class SceneHandler {
    private static int currentSceneIndex = 0;

    public static void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
