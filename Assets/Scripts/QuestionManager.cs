using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public static class TopicManager
{
    public static string SelectedTopic { get; set; }
}

public class QuestionManager : MonoBehaviour
{
    public QuestionDatabase questionDatabase;
    public Button daaButton;
    public Button dbmsButton;
    public Button openGLButton;

    void Start()
    {
        questionDatabase = new QuestionDatabase();

        daaButton.onClick.AddListener(() => SetTopic("DAA"));
        dbmsButton.onClick.AddListener(() => SetTopic("DBMS"));
        openGLButton.onClick.AddListener(() => SetTopic("OpenGL"));
    }

    void SetTopic(string topic)
    {
        TopicManager.SelectedTopic = topic;
        Debug.Log("Selected Topic: " + TopicManager.SelectedTopic);
    }
}
