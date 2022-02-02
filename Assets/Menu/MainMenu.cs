using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        PlayerCameraScript.menuOpened = false;
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        PlayerCameraScript.menuOpened = true;
        transform.parent.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
