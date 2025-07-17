using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;
using Cinemachine;

public class TriggerCode : MonoBehaviour
{
    public static int count;
    public GameObject quiz;
    public GameObject gameover;
    public TMP_Text status;
    public float delay = 1.5f;
    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (other.CompareTag("Lava"))
        {
            
            gameover.SetActive(false);
            if (count < 3)
            {
                Debug.Log("It be working");
                quiz.SetActive(true);
                FreezeCamera();
                Time.timeScale = 0.0f; 
            }
            if (count == 3)
            {
                Debug.Log("TADAUM");
                Time.timeScale = 0.0f;
                gameover.SetActive(true);
                StartCoroutine(QuitGameAfterDelay());
            }
        }

        if (other.CompareTag("Win"))
        {
            Debug.Log("YAYAYAY");
            SceneManager.LoadScene(2);
            Time.timeScale = 0.0f;
        }
    }

    public void CorrectPressed()
    {
        status.text = "Correct Answer!";
        StartCoroutine(ResumeGameAfterDelay());
    }

    public void WrongPressed()
    {
        count++;
        StartCoroutine(ResumeGameAfterDelay());
    }

    private IEnumerator QuitGameAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        Application.Quit();
    }

    private IEnumerator ResumeGameAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1.0f;
        quiz.SetActive(false);
        UnfreezeCamera();

        if (count <= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FreezeCamera()
    {
        playerInput.CharacterController.Look.Disable();
        transform.Rotate(0, 0, 0);
    }

    private void UnfreezeCamera()
    {
        playerInput.CharacterController.Look.Enable();
    }

}