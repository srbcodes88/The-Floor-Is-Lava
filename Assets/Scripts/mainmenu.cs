using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayFunction()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitFunction()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
