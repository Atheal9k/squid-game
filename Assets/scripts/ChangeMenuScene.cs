using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMenuScene : MonoBehaviour
{

    public void changeMenu(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
        Time.timeScale = 1f;
    }


}
