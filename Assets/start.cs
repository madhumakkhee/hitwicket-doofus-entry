using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public Button startButton; // Reference to the button component

    private void Start()
    {
        // Get the button component if it's not already assigned in the Inspector
        if (!startButton)
        {
            startButton = GetComponent<Button>();
        }

        // Add a listener to the button's onClick event
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Game");
    }
}