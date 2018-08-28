using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 4f;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int currentSkinIndex = 0;
    public int currency = 0;
    public int skinAvailability = 1;

    public GameObject completeLevelUI;


    void start()
    {
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("CurrentSkin"))
        {
            // We had a previous session
            currentSkinIndex = PlayerPrefs.GetInt("CurrentSkin");
            currency = PlayerPrefs.GetInt("Currency");
            skinAvailability = PlayerPrefs.GetInt("SkinAvailability");
        }

        else
        {
            PlayerPrefs.SetInt("CurrentSkin", currentSkinIndex);
            PlayerPrefs.SetInt("Currency", currency);
            PlayerPrefs.SetInt("SkinAvailability", skinAvailability);
        }
    }


    public void CompleteLevel()
    {
        Debug.Log("Level won");
        completeLevelUI.SetActive(true);
        LevelHasEnded();
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            LevelHasEnded();
            Debug.Log("game over");
            Invoke("Restart", restartDelay);
        }
        
    }

    public void LevelHasEnded()
    {
        GameObject enableMoves = GameObject.FindWithTag("hazard");
        enableMoves.GetComponentInParent<AutoMove>().isAllowedToMove = false;
        GameObject enableDrag = GameObject.FindWithTag("player");
        enableDrag.GetComponentInParent<Drag>().canDrag = false;
        GameObject enableHoldMove = GameObject.FindWithTag("player");
        enableHoldMove.GetComponentInParent<HoldMove>().enabled = false;
       // GameObject enableFinish = GameObject.FindWithTag("finishLine");
      //  enableFinish.GetComponentInParent<AutoMove>().isAllowedToMove = false;
        Time.timeScale = 1f;
    }

    public void TapRelease()
    {
        GameObject enableMoves = GameObject.FindWithTag("hazard");
        enableMoves.GetComponentInParent<AutoMove>().isAllowedToMove = true;
        GameObject enableDrag = GameObject.FindWithTag("player");
        enableDrag.GetComponentInParent<Drag>().canDrag = true;
        GameObject enableFinish = GameObject.Find("FinishLine");
        enableFinish.GetComponentInParent<AutoMove>().isAllowedToMove = true;
    }

    void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
  
}
