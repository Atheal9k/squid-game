using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    //public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    private bool checkPauseMenu = false;

    void Update()
    {
        if (checkPauseMenu == true)
        {
            Time.timeScale = 0f;
        }
    }
	

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        checkPauseMenu = true;
        
        //GameIsPause = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        checkPauseMenu = false;
    }


    void OnApplicationFocus(bool pauseStatus)
    {
        if (pauseStatus)
        {
            //your app is NO LONGER in the background
            Resume();
        }
        else
        {
            //your app is now in the background
            Pause();
        }
    }

}
