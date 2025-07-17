using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons; // Array to hold references to all buttons

    void Start()
    {
        // Loop through all buttons to assign indices and click listeners
        for (int i = 0; i < buttons.Length; i++)
        {
            // Get the ButtonIndex component attached to the button
            ButtonIndex buttonIndex = buttons[i].GetComponent<ButtonIndex>();

            // If the ButtonIndex component is found, assign the index
            if (buttonIndex != null)
            {
                buttonIndex.index = i;
                // Add the click listener to the button
                buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex.index));
            }
        }
    }

    // Method to handle button click
    public void OnButtonClick(int index)
    {
        Debug.Log("Button " + index + " clicked.");
    }
}