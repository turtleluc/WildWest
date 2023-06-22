using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("You quit the game");
    }

    public void Restart()
    {
        SceneManager.LoadScene("test");
    }
     
}
