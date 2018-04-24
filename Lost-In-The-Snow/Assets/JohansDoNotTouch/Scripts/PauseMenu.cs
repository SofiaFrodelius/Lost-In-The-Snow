using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    GameObject pauseMenu;
    private void Awake()
    {
        pauseMenu = transform.GetChild(0).gameObject;
    }

}
