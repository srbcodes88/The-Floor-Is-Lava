using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class QuestionDisplay : MonoBehaviour
{
    public QuestionDatabase questionDatabase;
    public TMP_Text questionText;
    public TMP_Text feedbackText;
    public TMP_Text[] optionTexts;
    public Button[] optionButtons;
    private List<Question> currentQuestions;
    private Question currentQuestion;
    public GameObject triggerCodeObject;
    TriggerCode myScript;
    public static int livescount = 1;

    void Start()
    {
        questionDatabase = new QuestionDatabase();
        string topic = TopicManager.SelectedTopic;
        StartGame(topic);
        myScript = triggerCodeObject.GetComponent<TriggerCode>();
    }

    void StartGame(string topic)
    {
        currentQuestions = questionDatabase.GetQuestionsByTopic(topic);
        LoadRandomQuestion();
    }

    void LoadRandomQuestion()
    {
        if (currentQuestions.Count == 0)
        {
            questionText.text = "No topic selected!!";
            feedbackText.text = "No more questions available!";
            return;
        }

        int randomIndex = Random.Range(0, currentQuestions.Count);
        currentQuestion = currentQuestions[randomIndex];
        currentQuestions.RemoveAt(randomIndex);

        questionText.text = currentQuestion.questionText;
        for (int i = 0; i < optionTexts.Length; i++)
        {
            if (i < currentQuestion.options.Length)
            {
                optionTexts[i].text = currentQuestion.options[i];
                int index = i; // Capture index for closure
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void CheckAnswer(int selectedOptionIndex)
    {
        Debug.Log($"Selected Option: {selectedOptionIndex}, Correct Answer Index: {currentQuestion.correctAnswerIndex}");
        if (selectedOptionIndex == currentQuestion.correctAnswerIndex)
        {
            myScript.CorrectPressed();
        }
        else
        {
            feedbackText.text = $"Incorrect Answer. The correct answer was: " + currentQuestion.options[currentQuestion.correctAnswerIndex] + $"\nWarning! {3 - livescount++} attempts remaining!";
            myScript.WrongPressed();
        }
        LoadAfterDelay();
    }

    private IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        LoadRandomQuestion();
    }
}