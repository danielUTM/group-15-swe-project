using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonBehaviour : MonoBehaviour
{

    public void moveToGame()
    {
        SceneManager.LoadScene("AR_Main_Scene", LoadSceneMode.Single);
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
