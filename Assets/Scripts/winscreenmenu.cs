using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winscreenmenu : MonoBehaviour
{
    public void PlayFunction()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuFucntion()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitFunction()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
